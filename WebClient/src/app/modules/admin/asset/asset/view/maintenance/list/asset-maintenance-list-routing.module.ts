import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AssetMaintenanceListComponent } from './asset-maintenance-list.component';

const routes: Routes = [
  { path: '', component: AssetMaintenanceListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/asset-maintenance-add.module').then(x => x.AssetMaintenanceAddModule),
    data: {
      name: 'asset_maintenance_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'Edit'
      }
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/asset-maintenance-add.module').then(x => x.AssetMaintenanceAddModule),
    data: {
      name: 'asset_maintenance_add',
      breadcrumb: {
        icon: 'plus',
        title: 'Add'
      }
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AssetMaintenanceListRoutingModule { }
