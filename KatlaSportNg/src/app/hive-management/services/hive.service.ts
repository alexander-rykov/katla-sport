import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import { Hive } from '../models/hive';
import { HiveListItem } from '../models/hive-list-item';
import { HiveSectionListItem } from '../models/hive-section-list-item';
import { HiveSectionProductListItem } from '../models/hive-section-product-list-item';

@Injectable({
  providedIn: 'root'
})
export class HiveService {
  private url = environment.apiUrl + 'api/hives/';
  private sectionUrl = environment.apiUrl + 'api/sections/';

  constructor(private http: HttpClient) { }

  getHives(): Observable<Array<HiveListItem>> {
    return this.http.get<Array<HiveListItem>>(this.url);
  }

  getHive(hiveId: number): Observable<Hive> {
    return this.http.get<Hive>(`${this.url}${hiveId}`);
  }

  getHiveSections(hiveId: number): Observable<Array<HiveSectionListItem>> {
    return this.http.get<Array<HiveSectionListItem>>(`${this.url}${hiveId}/sections`);
  }

  getSectionProducts(productSectionId: number): Observable<Array<HiveSectionProductListItem>> {
    return this.http.get<Array<HiveSectionProductListItem>>(`${this.sectionUrl}${productSectionId}/products`);
  }


  addHive(hive: Hive): Observable<Hive> {
    return this.http.post<Hive>(this.url, hive);
  }

  updateHive(hive: Hive): Observable<Object> {
    return this.http.put<Object>(`${this.url}${hive.id}`, hive);
  }

  deleteHive(hiveId: number): Observable<Object> {
    return this.http.delete<Object>(`${this.url}${hiveId}`);
  }

  setHiveStatus(hiveId: number, deletedStatus: boolean): Observable<Object> {
    return this.http.put<Object>(`${this.url}${hiveId}/status/${deletedStatus}`, null);
  }
}
