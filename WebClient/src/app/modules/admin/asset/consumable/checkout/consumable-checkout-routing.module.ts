import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ConsumableCheckoutComponent } from './consumable-checkout.component';

const routes: Routes = [
  { path: '', component: ConsumableCheckoutComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ConsumableCheckoutRoutingModule { }
