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
      }
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
      }
    }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StatusListRoutingModule { }
