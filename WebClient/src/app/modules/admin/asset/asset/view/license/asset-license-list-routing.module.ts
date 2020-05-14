import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AssetLicenseListComponent } from './asset-license-list.component';

const routes: Routes = [
  { path: '', component: AssetLicenseListComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AssetLicenseListRoutingModule { }
