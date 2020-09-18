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
  ) {}

  events: SportEvent[];
  today: Date;
  ngOnInit(): void {
    this.today = new Date();
    this.sportEventService.getAll().subscribe(resp => {
      this.events = resp;
      console.log(typeof(this.events[2].startDate))
    });
  }
}
