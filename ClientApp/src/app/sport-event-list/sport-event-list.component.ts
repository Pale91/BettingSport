import { Component, OnInit } from '@angular/core';
import { SportEvent } from '../model/sport.event.model';
import { SportEventService } from '../service/sport.event.service';

@Component({
  selector: 'app-sport-event-list',
  templateUrl: './sport-event-list.component.html',
  styleUrls: ['./sport-event-list.component.css']
})
export class SportEventListComponent implements OnInit {

  constructor(
    private sportEventService: SportEventService
  ) { console.log("ctor")}

  events: SportEvent[];
  ngOnInit(): void {
    console.log("NgInit")
    this.sportEventService.getAll().subscribe(resp => {
      console.log("data:" + JSON.stringify(resp));
      this.events = resp;
    });
  }
}
