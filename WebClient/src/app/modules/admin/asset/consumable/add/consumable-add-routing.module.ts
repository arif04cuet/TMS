import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ConsumableAddComponent } from './consumable-add.component';

const routes: Routes = [
  { path: '', component: ConsumableAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ConsumableAddRoutingModule { }
