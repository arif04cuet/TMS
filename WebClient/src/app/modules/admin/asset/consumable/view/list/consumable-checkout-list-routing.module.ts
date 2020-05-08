import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ConsumableCheckoutListComponent } from './consumable-checkout-list.component';

const routes: Routes = [
  { path: '', component: ConsumableCheckoutListComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ConsumableCheckoutListRoutingModule { }
