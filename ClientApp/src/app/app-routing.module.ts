import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SportEventListComponent } from './sport-event-list/sport-event-list.component';

const routes: Routes = [
  {path: "", component: SportEventListComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
