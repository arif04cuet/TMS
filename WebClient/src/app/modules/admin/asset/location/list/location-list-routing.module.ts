import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LocationListComponent } from './location-list.component';

const routes: Routes = [
  { path: '', component: LocationListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/location-add.module').then(x => x.LocationAddModule),
    data: {
      name: 'location_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'Edit'
      }
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/location-add.module').then(x => x.LocationAddModule),
    data: {
      name: 'location_add',
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
export class LocationListRoutingModule { }
