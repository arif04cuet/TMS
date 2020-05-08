import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AccessoryCheckoutListComponent } from './accessory-checkout-list.component';

const routes: Routes = [
  { path: '', component: AccessoryCheckoutListComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccessoryCheckoutListRoutingModule { }
