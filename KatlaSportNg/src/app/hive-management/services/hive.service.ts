import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import { Hive } from '../models/hive';
import { HiveListItem } from '../models/hive-list-item';
import { HiveSectionListItem } from '../models/hive-section-list-item';

@Injectable({
  providedIn: 'root'
})
export class HiveService {
  private url = environment.apiUrl + 'api/hives/';

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
