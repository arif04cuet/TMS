import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ConsumableCheckoutHistoryComponent } from './consumable-checkout-history.component';

const routes: Routes = [
  { path: '', component: ConsumableCheckoutHistoryComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ConsumableCheckoutHistoryRoutingModule { }
