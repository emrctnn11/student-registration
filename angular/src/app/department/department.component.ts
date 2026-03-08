import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DxDataGridModule } from 'devextreme-angular';
import { RestService } from '@abp/ng.core';

@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  standalone: true,
  imports: [CommonModule, DxDataGridModule],
})
export class DepartmentComponent implements OnInit {
  departments: any[] = [];

  constructor(private restService: RestService) {}

  ngOnInit(): void {
    this.loadDepartments();
  }

  loadDepartments(): void {
    this.restService
      .request<any, any>(
        { method: 'GET', url: '/api/app/department' },
        { apiName: 'default' }
      )
      .subscribe(result => {
        this.departments = result.items;
      });
  }

  onRowInserting(e: any): void {
    this.restService
      .request<any, any>(
        { method: 'POST', url: '/api/app/department', body: e.data },
        { apiName: 'default' }
      )
      .subscribe(() => this.loadDepartments());
  }

  onRowUpdating(e: any): void {
    this.restService
      .request<any, any>(
        { method: 'PUT', url: `/api/app/department/${e.key.id}`, body: { ...e.oldData, ...e.newData } },
        { apiName: 'default' }
      )
      .subscribe(() => this.loadDepartments());
  }

  onRowRemoving(e: any): void {
    this.restService
      .request<any, any>(
        { method: 'DELETE', url: `/api/app/department/${e.key.id}` },
        { apiName: 'default' }
      )
      .subscribe(() => this.loadDepartments());
  }
  
}