import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AllocationCheckoutComponent } from './allocation-checkout.component';

const routes: Routes = [
  { path: '', component: AllocationCheckoutComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AllocationCheckoutRoutingModule { }
