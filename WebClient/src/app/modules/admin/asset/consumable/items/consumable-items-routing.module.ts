import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ConsumableItemsComponent } from './consumable-items.component';

const routes: Routes = [
  { path: '', component: ConsumableItemsComponent },
  {
    path: ':itemId/view',
    loadChildren: () => import('../view/consumable-view.module').then(x => x.ConsumableViewModule),
    data: {
      name: 'consumable_view',
      breadcrumb: {
        icon: 'eye',
        title: 'View'
      }
    }
  },
  {
    path: ':itemId/checkout',
    loadChildren: () => import('../checkout/consumable-checkout.module').then(x => x.ConsumableCheckoutModule),
    data: {
      name: 'consumable_checkout',
      breadcrumb: {
        icon: 'eye',
        title: 'Checkout'
      }
    }
  },

  {
    path: ':itemId/checkin',
    loadChildren: () => import('../checkin/consumable-checkin.module').then(x => x.ConsumableCheckinModule),
    data: {
      name: 'consumable_checkin',
      breadcrumb: {
        icon: 'eye',
        title: 'Checkin'
      }
    }
  },
  {
    path: ':itemId/edit',
    loadChildren: () => import('../add/consumable-add.module').then(x => x.ConsumableAddModule),
    data: {
      name: 'consumable_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'Edit'
      }
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/consumable-add.module').then(x => x.ConsumableAddModule),
    data: {
      name: 'consumable_add',
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
export class ConsumableItemsRoutingModule { }
