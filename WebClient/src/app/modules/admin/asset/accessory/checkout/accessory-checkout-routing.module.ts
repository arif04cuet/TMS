import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AccessoryCheckoutComponent } from './accessory-checkout.component';

const routes: Routes = [
  { path: '', component: AccessoryCheckoutComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccessoryCheckoutRoutingModule { }
