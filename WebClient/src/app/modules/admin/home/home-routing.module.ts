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
        data: {
          name: 'user_list',
          breadcrumb: {
            icon: 'team',
            title: 'users'
          }
        }
      },
      {
        path: 'roles',
        loadChildren: () => import('../user/role/list/role-list.module').then(x => x.RoleListModule),
        data: {
          name: 'role_list',
          breadcrumb: {
            icon: 'safety',
            title: 'roles'
          }
        }
      },
      {
        path: 'designations',
        loadChildren: () => import('../user/designation/list/designation-list.module').then(x => x.DesignationListModule),
        data: {
          name: 'designation_list',
          breadcrumb: {
            icon: 'safety',
            title: 'designations'
          }
        }
      },
      {
        path: 'departments',
        loadChildren: () => import('../user/department/list/department-list.module').then(x => x.DepartmentListModule),
        data: {
          name: 'department_list',
          breadcrumb: {
            icon: 'safety',
            title: 'departments'
          }
        }
      },
      {
        path: 'profile',
        loadChildren: () => import('../user/profile/view/profile-view.module').then(x => x.ProfileViewModule),
        data: {
          name: 'profile_view',
          breadcrumb: {
            icon: 'safety',
            title: 'profile'
          }
        }
      },
      {
        path: 'libraries',
        loadChildren: () => import('../library/library/list/library-list.module').then(x => x.LibraryListModule),
        data: {
          name: 'library_list',
          breadcrumb: {
            icon: 'safety',
            title: 'libraries'
          }
        }
      },
      {
        path: 'asset/vendors',
        loadChildren: () => import('../asset/vendors/list/vendor-list.module').then(x => x.VendorListModule),
        data: {
          name: 'vendor_list',
          breadcrumb: {
            icon: 'safety',
            title: 'vendors'
          }
        }
      }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
