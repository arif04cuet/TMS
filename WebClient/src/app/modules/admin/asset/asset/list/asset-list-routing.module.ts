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
        title: 'View'
      }
    }
  },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/asset-add.module').then(x => x.AssetAddModule),
    data: {
      name: 'asset_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'Edit'
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
        title: 'Add'
      }
    }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AssetListRoutingModule { }
