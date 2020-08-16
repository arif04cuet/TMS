import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FacilitiesListComponent } from './facilities-list.component';

const routes: Routes = [
  { path: '', component: FacilitiesListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/facilities-add.module').then(x => x.FacilitiesAddModule),
    data: {
      name: 'facilities_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'edit'
      },
      permissions: ['room.facilities.manage', 'room.facilities.update']
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/facilities-add.module').then(x => x.FacilitiesAddModule),
    data: {
      name: 'facilities_add',
      breadcrumb: {
        icon: 'plus',
        title: 'add'
      },
      permissions: ['room.facilities.manage', 'room.facilities.create']
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FacilitiesListRoutingModule { }
