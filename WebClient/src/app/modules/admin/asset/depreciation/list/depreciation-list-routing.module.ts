import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DepreciationListComponent } from './depreciation-list.component';

const routes: Routes = [
  { path: '', component: DepreciationListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/depreciation-add.module').then(x => x.DepreciationAddModule),
    data: {
      name: 'depreciation_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'Edit'
      },
      permissions: ['depreciation.manage', 'depreciation.update']
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/depreciation-add.module').then(x => x.DepreciationAddModule),
    data: {
      name: 'depreciation_add',
      breadcrumb: {
        icon: 'plus',
        title: 'Add'
      },
      permissions: ['depreciation.manage', 'depreciation.create']
    }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DepreciationListRoutingModule { }
