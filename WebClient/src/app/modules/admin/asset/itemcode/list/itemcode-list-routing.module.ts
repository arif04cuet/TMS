import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ItemCodeListComponent } from './itemcode-list.component';

const routes: Routes = [
  { path: '', component: ItemCodeListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/itemcode-add.module').then(x => x.ItemCodeAddModule),
    data: {
      name: 'itemcode_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'Edit'
      }
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/itemcode-add.module').then(x => x.ItemCodeAddModule),
    data: {
      name: 'itemcode_add',
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
export class ItemCodeListRoutingModule { }
