import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LicenseCheckoutHistoryComponent } from './license-checkout-history.component';

const routes: Routes = [
  { path: '', component: LicenseCheckoutHistoryComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LicenseCheckoutHistoryRoutingModule { }
