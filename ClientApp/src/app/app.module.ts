import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { WheatherComponent } from './wheather/wheather.component';
import { WeatherService } from './service/wheather.service';
import { SportEventService } from './service/sport.event.service';
import { SportEventComponent } from './sport-event/sport-event.component';
import { SportEventListComponent } from './sport-event-list/sport-event-list.component';



@NgModule({
  declarations: [
    AppComponent,
    WheatherComponent,
    SportEventComponent,
    SportEventListComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [WeatherService, SportEventService],
  bootstrap: [AppComponent]
})
export class AppModule { }
