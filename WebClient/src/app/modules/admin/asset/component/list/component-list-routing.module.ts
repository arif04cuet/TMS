import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ComponentListComponent } from './component-list.component';

const routes: Routes = [
  { path: '', component: ComponentListComponent },
  {
    path: ':id/view',
    loadChildren: () => import('../view/component-view.module').then(x => x.ComponentViewModule),
    data: {
      name: 'component_view',
      breadcrumb: {
        icon: 'eye',
        title: 'View'
      }
    }
  },
  {
    path: ':id/checkout',
    loadChildren: () => import('../checkout/component-checkout.module').then(x => x.ComponentCheckoutModule),
    data: {
      name: 'component_checkout',
      breadcrumb: {
        icon: 'eye',
        title: 'Checkout'
      }
    }
  },

  {
    path: ':id/checkin',
    loadChildren: () => import('../checkin/component-checkin.module').then(x => x.ComponentCheckinModule),
    data: {
      name: 'component_checkin',
      breadcrumb: {
        icon: 'eye',
        title: 'Checkin'
      }
    }
  },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/component-add.module').then(x => x.ComponentAddModule),
    data: {
      name: 'component_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'Edit'
      }
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/component-add.module').then(x => x.ComponentAddModule),
    data: {
      name: 'component_add',
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
export class ComponentListRoutingModule { }
