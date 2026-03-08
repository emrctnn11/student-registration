import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map, shareReplay, tap } from 'rxjs';

export interface ProvinceData {
  province: string;
  districts: string[];
}

@Injectable({
  providedIn: 'root'
})
export class TurkeyGeoService {
  private geoData$: Observable<ProvinceData[]>;
  private districtMap = new Map<string, string[]>();
  private provinceList: string[] = [];

  constructor(private http: HttpClient) {
    this.geoData$ = this.http.get<ProvinceData[]>('/assets/turkey-geo.json').pipe(
      tap(data => {
        this.provinceList = data.map(d => d.province);
        data.forEach(d => this.districtMap.set(d.province, d.districts));
      }),
      shareReplay(1)
    );
  }

  getProvinces(): Observable<string[]> {
    return this.geoData$.pipe(
      map(data => data.map(d => d.province))
    );
  }

  getDistricts(province: string): Observable<string[]> {
    return this.geoData$.pipe(
      map(data => {
        const found = data.find(d => d.province === province);
        return found ? found.districts : [];
      })
    );
  }

  /** Synchronous lookup — only works after geoData$ has been subscribed to at least once */
  getDistrictsSync(province: string): string[] {
    return this.districtMap.get(province) ?? [];
  }

  getProvincesSync(): string[] {
    return this.provinceList;
  }
}