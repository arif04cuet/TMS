import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HostelListComponent } from './hostel-list.component';

const routes: Routes = [
  { path: '', component: HostelListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/hostel-add.module').then(x => x.HostelAddModule),
    data: {
      name: 'hostel_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'edit'
      }
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/hostel-add.module').then(x => x.HostelAddModule),
    data: {
      name: 'hostel_add',
      breadcrumb: {
        icon: 'plus',
        title: 'add'
      }
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HostelListRoutingModule { }
