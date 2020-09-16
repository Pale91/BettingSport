import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { WheatherComponent } from './wheather/wheather.component';

const routes: Routes = [
  {path: "weather", component: WheatherComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
