import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RequisitionListComponent } from './requisition-list.component';

const routes: Routes = [
  { path: '', component: RequisitionListComponent },
  // {
  //   path: ':id/view',
  //   loadChildren: () => import('../view/asset-view.module').then(x => x.AssetViewModule),
  //   data: {
  //     name: 'asset_view',
  //     breadcrumb: {
  //       icon: 'eye',
  //       title: 'view'
  //     },
  //     permissions: ['asset.manage', 'asset.view']
  //   }
  // },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/requisition-add.module').then(x => x.RequisitionAddModule),
    data: {
      name: 'requisition_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'edit'
      },
      permissions: ['requisition.manage', 'requisition.update']
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/requisition-add.module').then(x => x.RequisitionAddModule),
    data: {
      name: 'requisition_add',
      breadcrumb: {
        icon: 'plus',
        title: 'add'
      },
      permissions: ['requisition.manage', 'requisition.create']
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RequisitionListRoutingModule { }
