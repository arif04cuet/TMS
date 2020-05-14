import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AssetAuditListComponent } from './asset-audit-list.component'; 

const routes: Routes = [
  { path: '', component: AssetAuditListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/asset-audit-add.module').then(x => x.AssetAuditAddModule),
    data: {
      name: 'asset_audit_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'Edit'
      }
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/asset-audit-add.module').then(x => x.AssetAuditAddModule),
    data: {
      name: 'asset_audit_add',
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
export class AssetAuditListRoutingModule { }
