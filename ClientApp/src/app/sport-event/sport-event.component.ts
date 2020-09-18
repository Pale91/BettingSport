import { Component, Input, OnInit, SimpleChanges } from '@angular/core';
import { SportEvent } from '../model/sport.event.model';
import { SportEventService } from '../service/sport.event.service';

@Component({
  selector: '[app-sport-event]',
  templateUrl: './sport-event.component.html',
  styleUrls: ['./sport-event.component.css']
})
export class SportEventComponent implements OnInit {

  constructor(
  ) { }

  @Input() _event: SportEvent;
  @Input() onEditMode: boolean;
  fieldToEdit: string;

  ngOnInit(): void {
  }

  ngOnChanges(changes: SimpleChanges) {
    if(!changes.onEditMode.currentValue) {
      this.fieldToEdit = "";
    }
  }

  editField(fiedlName: string) {
    if (this.onEditMode) {
      this.fieldToEdit = fiedlName;
    }
  }
}
