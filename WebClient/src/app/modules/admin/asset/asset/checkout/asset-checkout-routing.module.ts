import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AssetCheckoutComponent } from './asset-checkout.component';

const routes: Routes = [
  { path: '', component: AssetCheckoutComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AssetCheckoutRoutingModule { }
