import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SportEvent } from '../model/sport.event.model';
import { PageResponse } from '../model/page-response.model';

@Injectable()
export class SportEventService {
  constructor(private http: HttpClient) { 
      this.apiUrl = "/api/sportevent/";
  }
  private apiUrl: string;

  getAll(): Observable<PageResponse<SportEvent>> {
    return this.http.get<PageResponse<SportEvent>>(this.apiUrl);
  }

  create(event: SportEvent): Observable<SportEvent> {
    return this.http.post<SportEvent>(this.apiUrl, event);
  }

  update(event: SportEvent): Observable<SportEvent> {
    return this.http.put<SportEvent>(this.apiUrl + event.id, event);
  }

  delete(id: number): Observable<object> {
    return this.http.delete(this.apiUrl + id);
  }
}
