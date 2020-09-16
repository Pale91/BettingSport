import { Component, OnInit } from '@angular/core';
import { Weather } from '../model/weather.model';
import { WeatherService } from '../service/wheather.service';

@Component({
  selector: 'app-wheather',
  templateUrl: './wheather.component.html',
  styleUrls: ['./wheather.component.css']
})
export class WheatherComponent implements OnInit {

  constructor(
    private weatherService: WeatherService
  ) { }
  forecast: Weather[];

  ngOnInit(): void {
    this.weatherService.getWeather().subscribe(resp => {
      this.forecast = resp;
      this.forecast.forEach(x => console.log(x.summary));
    })
  }

}
