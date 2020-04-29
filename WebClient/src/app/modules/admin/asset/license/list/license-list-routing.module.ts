import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LicenseListComponent } from './license-list.component';

const routes: Routes = [
  { path: '', component: LicenseListComponent },

  {
    path: ':id/view',
    loadChildren: () => import('../view/license-view.module').then(x => x.LicenseViewModule),
    data: {
      name: 'license_view',
      breadcrumb: {
        icon: 'eye',
        title: 'View'
      }
    }
  },


  {
    path: ':id/edit',
    loadChildren: () => import('../add/license-add.module').then(x => x.LicenseAddModule),
    data: {
      name: 'license_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'Edit'
      }
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/license-add.module').then(x => x.LicenseAddModule),
    data: {
      name: 'license_add',
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
export class LicenseListRoutingModule { }
