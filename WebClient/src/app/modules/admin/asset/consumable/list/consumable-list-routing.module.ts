import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ConsumableListComponent } from './consumable-list.component';

const routes: Routes = [
  { path: '', component: ConsumableListComponent },
  {
    path: ':id/items',
    loadChildren: () => import('../items/consumable-items.module').then(x => x.ConsumableItemsModule),
    data: {
      name: 'consumable_items',
      breadcrumb: {
        icon: 'eye',
        title: 'view'
      },
      permissions: ['consumable.item.manage', 'consumable.item.list']
    }
  },
  {
    path: ':id/view',
    loadChildren: () => import('../view/consumable-view.module').then(x => x.ConsumableViewModule),
    data: {
      name: 'consumable_view',
      breadcrumb: {
        icon: 'eye',
        title: 'view'
      },
      permissions: ['consumable.manage', 'consumable.view']
    }
  },
  {
    path: ':id/checkout',
    loadChildren: () => import('../checkout/consumable-checkout.module').then(x => x.ConsumableCheckoutModule),
    data: {
      name: 'consumable_checkout',
      breadcrumb: {
        icon: 'eye',
        title: 'checkout'
      },
      permissions: ['consumable.manage', 'consumable.checkout']
    }
  },

  {
    path: ':id/checkin',
    loadChildren: () => import('../checkin/consumable-checkin.module').then(x => x.ConsumableCheckinModule),
    data: {
      name: 'consumable_checkin',
      breadcrumb: {
        icon: 'eye',
        title: 'checkin'
      },
      permissions: ['consumable.manage', 'consumable.checkin']
    }
  },
  // {
  //   path: ':id/edit',
  //   loadChildren: () => import('../add/consumable-add.module').then(x => x.ConsumableAddModule),
  //   data: {
  //     name: 'consumable_edit',
  //     breadcrumb: {
  //       icon: 'edit',
  //       title: 'Edit'
  //     }
  //   }
  // },
  {
    path: 'add',
    loadChildren: () => import('../add/consumable-add.module').then(x => x.ConsumableAddModule),
    data: {
      name: 'consumable_add',
      breadcrumb: {
        icon: 'plus',
        title: 'Add'
      },
      permissions: ['consumable.manage', 'consumable.create']
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ConsumableListRoutingModule { }
