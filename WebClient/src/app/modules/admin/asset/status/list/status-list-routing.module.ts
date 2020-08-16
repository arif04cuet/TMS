import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StatusListComponent } from './status-list.component';

const routes: Routes = [
  { path: '', component: StatusListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/status-add.module').then(x => x.StatusAddModule),
    data: {
      name: 'status_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'Edit'
      },
      permissions: ['asset.status.manage', 'asset.status.update']
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/status-add.module').then(x => x.StatusAddModule),
    data: {
      name: 'status_add',
      breadcrumb: {
        icon: 'plus',
        title: 'Add'
      },
      permissions: ['asset.status.manage', 'asset.status.create']
    }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StatusListRoutingModule { }
