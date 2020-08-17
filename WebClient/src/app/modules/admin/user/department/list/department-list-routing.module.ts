import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DepartmentListComponent } from './department-list.component';

const routes: Routes = [
  { path: '', component: DepartmentListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/department-add.module').then(x => x.DepartmentAddModule),
    data: {
      name: 'department_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'edit'
      },
      permissions: ['department.manage', 'department.update']
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/department-add.module').then(x => x.DepartmentAddModule),
    data: {
      name: 'department_add',
      breadcrumb: {
        icon: 'plus',
        title: 'add'
      },
      permissions: ['department.manage', 'department.create']
    }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DepartmentListRoutingModule { }
