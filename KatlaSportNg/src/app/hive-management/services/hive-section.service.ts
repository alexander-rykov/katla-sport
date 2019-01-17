import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import { HiveSection } from '../models/hive-section';
import { HiveSectionListItem } from '../models/hive-section-list-item';

@Injectable({
  providedIn: 'root'
})
export class HiveSectionService {
  private url = environment.apiUrl + 'api/sections/';

  constructor(private http: HttpClient) { }

  getHiveSections(): Observable<Array<HiveSectionListItem>> {
    return this.http.get<Array<HiveSectionListItem>>(this.url);
  }

  getHiveSection(hiveSectionId: number): Observable<HiveSection> {
    return this.http.get<HiveSection>(`${this.url}${hiveSectionId}`);
  }

  setHiveSectionStatus(hiveSectionId: number, deletedStatus: boolean): Observable<Object> {
    const params = new HttpParams().set('hive_id',hiveSectionId.toString()).set('deleted_status',deletedStatus.toString());
    return this.http.put(`${this.url}${hiveSectionId}/status/${deletedStatus}`,params);
  }
}
