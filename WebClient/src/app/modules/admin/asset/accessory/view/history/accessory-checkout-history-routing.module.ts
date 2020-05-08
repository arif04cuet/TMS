import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AccessoryCheckoutHistoryComponent } from './accessory-checkout-history.component';

const routes: Routes = [
  { path: '', component: AccessoryCheckoutHistoryComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccessoryCheckoutHistoryRoutingModule { }
