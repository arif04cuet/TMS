import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DesignationListComponent } from './designation-list.component';

const routes: Routes = [
  { path: '', component: DesignationListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/designation-add.module').then(x => x.DesignationAddModule),
    data: {
      name: 'designation_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'edit'
      }
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/designation-add.module').then(x => x.DesignationAddModule),
    data: {
      name: 'designation_add',
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
export class DesignationListRoutingModule { }
