import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ConsumableCheckinComponent } from './consumable-checkin.component';

const routes: Routes = [
  { path: '', component: ConsumableCheckinComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ConsumableCheckinRoutingModule { }
