import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserListComponent } from './user-list.component';

const routes: Routes = [
  { path: '', component: UserListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/user-add.module').then(x => x.UserAddModule),
    data: {
      name: 'user_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'edit'
      },
      permissions: ['user.manage', 'user.update']
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/user-add.module').then(x => x.UserAddModule),
    data: {
      name: 'user_add',
      breadcrumb: {
        icon: 'plus',
        title: 'add'
      },
      permissions: ['user.manage', 'user.create']
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserListRoutingModule { }
