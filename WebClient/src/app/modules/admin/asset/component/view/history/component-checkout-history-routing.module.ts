import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ComponentCheckoutHistoryComponent } from './component-checkout-history.component';

const routes: Routes = [
  { path: '', component: ComponentCheckoutHistoryComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ComponentCheckoutHistoryRoutingModule { }
