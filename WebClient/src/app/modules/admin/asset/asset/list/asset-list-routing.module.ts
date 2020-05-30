import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AssetListComponent } from './asset-list.component';

const routes: Routes = [
  { path: '', component: AssetListComponent },
  {
    path: ':id/view',
    loadChildren: () => import('../view/asset-view.module').then(x => x.AssetViewModule),
    data: {
      name: 'asset_view',
      breadcrumb: {
        icon: 'eye',
        title: 'view'
      }
    }
  },
  {
    path: ':id/edit',
    loadChildren: () => import('../edit/asset-edit.module').then(x => x.AssetEditModule),
    data: {
      name: 'asset_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'edit'
      }
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/asset-add.module').then(x => x.AssetAddModule),
    data: {
      name: 'asset_add',
      breadcrumb: {
        icon: 'plus',
        title: 'add'
      }
    }
  },
  {
    path: ':id/checkout',
    loadChildren: () => import('../checkout/asset-checkout.module').then(x => x.AssetCheckoutModule),
    data: {
      name: 'asset_checkout',
      breadcrumb: {
        icon: 'plus',
        title: 'checkout'
      }
    }
  },
  {
    path: 'checkout/bulk',
    loadChildren: () => import('../bulk-checkout/asset-bulk-checkout.module').then(x => x.AssetBulkCheckoutModule),
    data: {
      name: 'asset_bulk_checkout',
      breadcrumb: {
        icon: 'plus',
        title: 'checkout'
      }
    }
  },
  {
    path: ':id/checkin',
    loadChildren: () => import('../checkin/asset-checkin.module').then(x => x.AssetCheckinModule),
    data: {
      name: 'asset_checkin',
      breadcrumb: {
        icon: 'plus',
        title: 'Add'
      }
    }
  },
  {
    path: 'audit/add',
    loadChildren: () => import('../audit/add/asset-audit-add-routing.module').then(x => x.AssetAuditAddRoutingModule),
    data: {
      name: 'asset_audit',
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
export class AssetListRoutingModule { }
