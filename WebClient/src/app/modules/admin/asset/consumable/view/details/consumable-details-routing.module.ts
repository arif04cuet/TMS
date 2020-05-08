import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ConsumableDetailsComponent } from './consumable-details.component';

const routes: Routes = [
  { path: '', component: ConsumableDetailsComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ConsumableDetailsRoutingModule { }
