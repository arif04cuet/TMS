import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AssetBulkCheckoutComponent } from './asset-bulk-checkout.component';

const routes: Routes = [
  { path: '', component: AssetBulkCheckoutComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AssetBulkCheckoutRoutingModule { }
