import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LicenseCheckoutComponent } from './license-checkout.component';

const routes: Routes = [
  { path: '', component: LicenseCheckoutComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LicenseCheckoutRoutingModule { }
