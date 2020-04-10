import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    children: [
      {
        path: 'users',
        loadChildren: () => import('../user/user/list/user-list.module').then(x => x.UserListModule),
        data: { name: 'user_list' }
      },
      {
        path: 'roles',
        loadChildren: () => import('../user/role/list/role-list.module').then(x => x.RoleListModule),
        data: { name: 'role_list' }
      },
      {
        path: 'designations',
        loadChildren: () => import('../user/designation/list/designation-list.module').then(x => x.DesignationListModule),
        data: { name: 'designation_list' }
      },
      {
        path: 'profile',
        loadChildren: () => import('../user/profile/view/profile-view.module').then(x => x.ProfileViewModule),
        data: { name: 'profile_view' }
      }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
