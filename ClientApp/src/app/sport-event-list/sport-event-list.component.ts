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
  onEditMode: boolean;
  ngOnInit(): void {
    this.onEditMode = false;
    this.refreshData();
  }

  refreshData() {
    this.sportEventService.getAll().subscribe(resp => {
      this.today = new Date();
      this.events = resp.data;
    });
  }

  toggleEditMode(value: boolean) {
    if(this.onEditMode != value && !value) {
      // if the value changed and is in preview mode, refresh data
      this.refreshData();
    }
    this.onEditMode = value;
  }

  addNew() {
    let date: Date = new Date();
    date.setHours(23, 59);
    let event: SportEvent = {
      startDate: date,
      id: 0,
      name: ""
    };

    this.sportEventService.create(event).subscribe(resp => {
      this.events.push(resp);
    });
  }

  deleteEvent(eventId: number) {
    this.events = this.events.filter(x => x.id != eventId);
  }
}
