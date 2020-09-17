import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SportEventComponent } from './sport-event.component';

describe('SportEventComponent', () => {
  let component: SportEventComponent;
  let fixture: ComponentFixture<SportEventComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SportEventComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SportEventComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
