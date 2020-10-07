import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ManufacturerListComponent } from './manufacturer-list.component';

const routes: Routes = [
  { path: '', component: ManufacturerListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/manufacturer-add.module').then(x => x.ManufacturerAddModule),
    data: {
      name: 'manufacturer_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'edit'
      },
      permissions: ['manufacturer.manage', 'manufacturer.update']
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/manufacturer-add.module').then(x => x.ManufacturerAddModule),
    data: {
      name: 'manufacturer_add',
      breadcrumb: {
        icon: 'plus',
        title: 'add'
      },
      permissions: ['manufacturer.manage', 'manufacturer.create']
    }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ManufacturerListRoutingModule { }
