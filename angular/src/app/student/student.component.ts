import { Component, OnInit, OnDestroy } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DxDataGridModule, DxSelectBoxModule } from 'devextreme-angular';
import { RestService } from '@abp/ng.core';
import { TurkeyGeoService } from '../shared/geo/turkey-geo.service';
import { HttpClient } from '@angular/common/http';
import * as signalR from '@microsoft/signalr';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  standalone: true,
  imports: [CommonModule, DxDataGridModule, DxSelectBoxModule],
})
export class StudentComponent implements OnInit, OnDestroy {
  students: any[] = [];
  departments: any[] = [];
  provinces: string[] = [];
  currentDistricts: string[] = [];
  private hubConnection: signalR.HubConnection;

  constructor(
    private restService: RestService,
    private geoService: TurkeyGeoService,
    private http: HttpClient,
  ) {}

  ngOnInit(): void {
    this.loadStudents();
    this.loadDepartments();
    this.loadProvinces();
    this.startSignalRConnection();
  }

  ngOnDestroy(): void {
    this.hubConnection?.stop();
  }

  loadStudents(): void {
    this.restService
      .request<any, any>({ method: 'GET', url: '/api/app/student' }, { apiName: 'default' })
      .subscribe(result => {
        this.students = result.items;
      });
  }

  loadDepartments(): void {
    this.restService
      .request<any, any>({ method: 'GET', url: '/api/app/department' }, { apiName: 'default' })
      .subscribe(result => {
        this.departments = result.items;
      });
  }

  loadProvinces(): void {
    this.geoService.getProvinces().subscribe(p => {
      this.provinces = p;
    });
  }

  onEditingStart(e: any): void {
    const province = e.data?.province;
    this.currentDistricts = province ? this.geoService.getDistrictsSync(province) : [];
  }

  onProvinceChanged(e: any, cellInfo: any): void {
    cellInfo.setValue(e.value);
    this.currentDistricts = e.value ? this.geoService.getDistrictsSync(e.value) : [];
    cellInfo.component.cellValue(cellInfo.rowIndex, 'district', null);
  }

  onEditorPreparing(e: any): void {
    if (e.dataField === 'nationalId') {
      e.editorOptions = {
        ...e.editorOptions,
        maxLength: 11,
      };
    }
  }

  onRowInserting(e: any): void {
    this.restService
      .request<
        any,
        any
      >({ method: 'POST', url: '/api/app/student', body: e.data }, { apiName: 'default' })
      .subscribe({
        next: () => this.loadStudents(),
        error: err => {
          const msg = err?.error?.error?.message ?? 'Quota is full for this department.';
          alert(msg);
          e.cancel = true;
        },
      });
  }

  onRowUpdating(e: any): void {
    this.restService
      .request<
        any,
        any
      >({ method: 'PUT', url: `/api/app/student/${e.key.id}`, body: { ...e.oldData, ...e.newData } }, { apiName: 'default' })
      .subscribe({
        next: () => this.loadStudents(),
        error: err => {
          const msg = err?.error?.error?.message ?? 'Quota is full for this department.';
          alert(msg);
          e.cancel = true;
        },
      });
  }

  onRowRemoving(e: any): void {
    this.restService
      .request<
        any,
        any
      >({ method: 'DELETE', url: `/api/app/student/${e.key.id}` }, { apiName: 'default' })
      .subscribe(() => this.loadStudents());
  }

  startSignalRConnection(): void {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:44323/signalr-hubs/student', {
        skipNegotiation: false,
        transport: signalR.HttpTransportType.WebSockets | signalR.HttpTransportType.LongPolling,
      })
      .withAutomaticReconnect()
      .build();

    this.hubConnection.on('StudentChanged', (data) => {
      console.log("student added: ", data);
      this.loadStudents();
    });

    this.hubConnection
      .start()
      .then(() => console.log('SignalR connected!'))
      .catch(err => console.error('SignalR error:', err));
  }
}
