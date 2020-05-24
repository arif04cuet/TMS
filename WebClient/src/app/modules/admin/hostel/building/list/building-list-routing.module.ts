import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BuildingListComponent } from './building-list.component';

const routes: Routes = [
  { path: '', component: BuildingListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/building-add.module').then(x => x.BuildingAddModule),
    data: {
      name: 'building_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'edit'
      }
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/building-add.module').then(x => x.BuildingAddModule),
    data: {
      name: 'building_add',
      breadcrumb: {
        icon: 'plus',
        title: 'add'
      }
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BuildingListRoutingModule { }
