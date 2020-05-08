import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ComponentCheckoutComponent } from './component-checkout.component';

const routes: Routes = [
  { path: '', component: ComponentCheckoutComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ComponentCheckoutRoutingModule { }
