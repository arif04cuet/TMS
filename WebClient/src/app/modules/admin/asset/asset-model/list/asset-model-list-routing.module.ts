import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AssetModelListComponent } from './asset-model-list.component';

const routes: Routes = [
  { path: '', component: AssetModelListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/asset-model-add.module').then(x => x.AssetModelAddModule),
    data: {
      name: 'asset_model_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'Edit'
      },
      permissions: ['asset.model.manage', 'asset.model.update']
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/asset-model-add.module').then(x => x.AssetModelAddModule),
    data: {
      name: 'asset_model_add',
      breadcrumb: {
        icon: 'plus',
        title: 'Add'
      },
      permissions: ['asset.model.manage', 'asset.model.create']
    }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AssetModelListRoutingModule { }
