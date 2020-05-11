import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AssetMaintenanceAddComponent } from './asset-maintenance-add.component';

const routes: Routes = [
  { path: '', component: AssetMaintenanceAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AssetMaintenanceAddRoutingModule { }
