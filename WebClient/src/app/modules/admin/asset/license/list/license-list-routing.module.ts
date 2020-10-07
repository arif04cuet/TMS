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
      },
      permissions: ['license.manage', 'license.view']
    }
  },


  {
    path: ':id/edit',
    loadChildren: () => import('../add/license-add.module').then(x => x.LicenseAddModule),
    data: {
      name: 'license_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'edit'
      },
      permissions: ['license.manage', 'license.update']
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/license-add.module').then(x => x.LicenseAddModule),
    data: {
      name: 'license_add',
      breadcrumb: {
        icon: 'plus',
        title: 'add'
      },
      permissions: ['license.manage', 'license.create']
    }
  },
  {
    path: ':id/checkout',
    loadChildren: () => import('../checkout/license-checkout.module').then(x => x.LicenseCheckoutModule),
    data: {
      name: 'license_checkout',
      breadcrumb: {
        icon: 'eye',
        title: 'checkout'
      },
      permissions: ['license.manage', 'license.checkout']
    }
  },
  {
    path: ':id/checkin',
    loadChildren: () => import('../checkin/license-checkin.module').then(x => x.LicenseCheckinModule),
    data: {
      name: 'license_checkin',
      breadcrumb: {
        icon: 'eye',
        title: 'checkin'
      },
      permissions: ['license.manage', 'license.checkin']
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LicenseListRoutingModule { }
