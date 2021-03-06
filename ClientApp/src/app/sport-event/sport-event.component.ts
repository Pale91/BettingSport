import { Component, EventEmitter, Input, OnInit, Output, SimpleChanges } from '@angular/core';
import { SportEvent } from '../model/sport.event.model';
import { SportEventService } from '../service/sport.event.service';

@Component({
  selector: '[app-sport-event]',
  templateUrl: './sport-event.component.html',
  styleUrls: ['./sport-event.component.css']
})
export class SportEventComponent implements OnInit {

  constructor(
    private eventService: SportEventService
  ) { }

  @Input() _event: SportEvent;
  @Input() onEditMode: boolean;
  @Output() delete: EventEmitter<number> = new EventEmitter();
  fieldToEdit: string;

  ngOnInit(): void {
  }

  ngOnChanges(changes: SimpleChanges) {
    if (!changes.onEditMode.currentValue) {
      this.fieldToEdit = "";
    }
  }

  clickField(fieldName: string) {
    if (this.onEditMode) {
      this.fieldToEdit = fieldName;
    } else {
      if (fieldName.startsWith("odd")) {
        console.log(`${this._event.id} ${fieldName} ${this._event[fieldName]}`)
      }
    }
  }

  save() {
    this.eventService.update(this._event).subscribe(resp => {
      this._event = resp;
    }, error => {
      console.log(error.status);
      alert(`An unexpected error happened while saving the event ${ this._event.name || this._event.id}: ${JSON.stringify(error.error.errors)}`)
    });
    this.fieldToEdit = "";
  }

  remove() {
    if(confirm(`Are you sure you would like to delete the event ${ this._event.name || this._event.id}`)){
      this.eventService.delete(this._event.id).subscribe(resp => {
        this.delete.emit(this._event.id);
      }, error => {
        alert(`An unexpected error happened while deleting the event ${ this._event.name || this._event.id}: ${JSON.stringify(error)}`)
      });
    }
  }
}
