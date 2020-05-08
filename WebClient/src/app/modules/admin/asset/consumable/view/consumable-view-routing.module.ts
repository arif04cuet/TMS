import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ConsumableViewComponent } from './consumable-view.component';

const routes: Routes = [
  { path: '', component: ConsumableViewComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ConsumableViewRoutingModule { }
