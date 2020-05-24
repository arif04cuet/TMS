import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RoomTypeListComponent } from './room-type-list.component';

const routes: Routes = [
  { path: '', component: RoomTypeListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/room-type-add.module').then(x => x.RoomTypeAddModule),
    data: {
      name: 'room_type_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'edit'
      }
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/room-type-add.module').then(x => x.RoomTypeAddModule),
    data: {
      name: 'room_type_add',
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
export class RoomTypeListRoutingModule { }
