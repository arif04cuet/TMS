import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { VendorListComponent } from './vendor-list.component';

const routes: Routes = [
  { path: '', component: VendorListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/vendor-add.module').then(x => x.VendorAddModule),
    data: {
      name: 'vendor_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'add'
      }
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/vendor-add.module').then(x => x.VendorAddModule),
    data: {
      name: 'vendor_add',
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
export class VendorListRoutingModule { }
