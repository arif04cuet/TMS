import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RoleListComponent } from './role-list.component';

const routes: Routes = [
  { path: '', component: RoleListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/role-add.module').then(x => x.RoleAddModule),
    data: { name: 'role_edit' }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/role-add.module').then(x => x.RoleAddModule),
    data: { name: 'role_add' }
  },
  {
    path: ':id/permissions',
    loadChildren: () => import('../../permission/permission.module').then(x => x.PermissionModule),
    data: { name: 'role_permissions' }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RoleListRoutingModule { }
