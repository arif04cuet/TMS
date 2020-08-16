import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SupplierListComponent } from './supplier-list.component';

const routes: Routes = [
  { path: '', component: SupplierListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/supplier-add.module').then(x => x.SupplierAddModule),
    data: {
      name: 'supplier_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'Edit'
      },
      permissions: ['supplier.manage', 'supplier.update']
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/supplier-add.module').then(x => x.SupplierAddModule),
    data: {
      name: 'supplier_add',
      breadcrumb: {
        icon: 'plus',
        title: 'Add'
      },
      permissions: ['supplier.manage', 'supplier.create']
    }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SupplierListRoutingModule { }
