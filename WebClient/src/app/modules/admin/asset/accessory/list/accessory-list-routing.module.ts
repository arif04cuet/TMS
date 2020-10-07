import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AccessoryListComponent } from './accessory-list.component';

const routes: Routes = [
  { path: '', component: AccessoryListComponent },
  {
    path: ':id/view',
    loadChildren: () => import('../view/accessory-view.module').then(x => x.AccessoryViewModule),
    data: {
      name: 'accessory_view',
      breadcrumb: {
        icon: 'eye',
        title: 'View'
      }
    }
  },
  {
    path: ':id/checkout',
    loadChildren: () => import('../checkout/accessory-checkout.module').then(x => x.AccessoryCheckoutModule),
    data: {
      name: 'accessory_checkout',
      breadcrumb: {
        icon: 'eye',
        title: 'Checkout'
      }
    }
  },

  {
    path: ':id/checkin',
    loadChildren: () => import('../checkin/accessory-checkin.module').then(x => x.AccessoryCheckinModule),
    data: {
      name: 'accessory_checkin',
      breadcrumb: {
        icon: 'eye',
        title: 'Checkin'
      }
    }
  },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/accessory-add.module').then(x => x.AccessoryAddModule),
    data: {
      name: 'accessory_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'edit'
      }
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/accessory-add.module').then(x => x.AccessoryAddModule),
    data: {
      name: 'accessory_add',
      breadcrumb: {
        icon: 'plus',
        title: 'add'
      }
    }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccessoryListRoutingModule { }
