import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AssetCheckoutHistoryComponent } from './asset-checkout-history.component';

const routes: Routes = [
  { path: '', component: AssetCheckoutHistoryComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AssetCheckoutHistoryRoutingModule { }
