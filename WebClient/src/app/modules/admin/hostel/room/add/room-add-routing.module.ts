import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RoomAddComponent } from './room-add.component';

const routes: Routes = [
  { path: '', component: RoomAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RoomAddRoutingModule { }
