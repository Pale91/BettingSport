import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { SportEventService } from './service/sport.event.service';
import { SportEventComponent } from './sport-event/sport-event.component';
import { SportEventListComponent } from './sport-event-list/sport-event-list.component';
import { JsonDateInterceptor } from './infrastructure/json-date.interceptor';



@NgModule({
  declarations: [
    AppComponent,
    SportEventComponent,
    SportEventListComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JsonDateInterceptor,
      multi: true
    },
    SportEventService],
  bootstrap: [AppComponent]
})
export class AppModule { }
