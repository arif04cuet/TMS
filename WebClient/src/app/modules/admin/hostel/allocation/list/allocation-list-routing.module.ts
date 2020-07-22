import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AllocationListComponent } from './allocation-list.component';

const routes: Routes = [
  { path: '', component: AllocationListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/allocation-add.module').then(x => x.AllocationAddModule),
    data: {
      name: 'allocation_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'edit'
      }
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/allocation-add.module').then(x => x.AllocationAddModule),
    data: {
      name: 'allocation_add',
      breadcrumb: {
        icon: 'plus',
        title: 'add'
      }
    }
  },
  {
    path: ':id/checkout',
    loadChildren: () => import('../checkout/allocation-checkout.module').then(x => x.AllocationCheckoutModule),
    data: {
      name: 'allocation_checkout',
      breadcrumb: {
        icon: 'plus',
        title: 'checkout'
      }
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AllocationListRoutingModule { }
