import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Weather } from '../model/weather.model';

@Injectable()
export class WeatherService {
  constructor(private http: HttpClient) { 
      this.apiUrl = "/api/weatherforecast";
  }
  private apiUrl: string;

  getWeather(): Observable<Weather[]> {
    return this.http.get<Weather[]>(this.apiUrl);
  }

}
