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
    this.sportEventService.getAll().subscribe(resp => {
      this.today = new Date();
      this.events = resp;
    });
  }

  toggleEditMode(value: boolean) {
    this.onEditMode = value;
  }
}
