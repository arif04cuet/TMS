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
      },
      permissions: ['allocation.manage', 'allocation.update']
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
      },
      permissions: ['allocation.manage', 'allocation.create']
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
      },
      permissions: ['allocation.manage', 'allocation.checkout']
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AllocationListRoutingModule { }
