import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OfficeListComponent } from './office-list.component';

const routes: Routes = [
  { path: '', component: OfficeListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/office-add.module').then(x => x.OfficeAddModule),
    data: {
      name: 'office_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'edit'
      },
      permissions: ['designation.manage', 'designation.update']
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/office-add.module').then(x => x.OfficeAddModule),
    data: {
      name: 'office_add',
      breadcrumb: {
        icon: 'plus',
        title: 'add'
      },
      permissions: ['designation.manage', 'designation.create']
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OfficeListRoutingModule { }
