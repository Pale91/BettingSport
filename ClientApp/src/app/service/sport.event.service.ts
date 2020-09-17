import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SportEvent } from '../model/sport.event.model';

@Injectable()
export class SportEventService {
  constructor(private http: HttpClient) { 
      this.apiUrl = "/api/sportevent";
  }
  private apiUrl: string;

  getAll(): Observable<SportEvent[]> {
    return this.http.get<SportEvent[]>(this.apiUrl);
  }

}
