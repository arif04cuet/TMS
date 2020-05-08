import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ComponentCheckoutListComponent } from './component-checkout-list.component';

const routes: Routes = [
  { path: '', component: ComponentCheckoutListComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ComponentCheckoutListRoutingModule { }
