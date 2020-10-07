import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RoomListComponent } from './room-list.component';

const routes: Routes = [
  { path: '', component: RoomListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/room-add.module').then(x => x.RoomAddModule),
    data: {
      name: 'room_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'edit'
      },
      permissions: ['room.manage', 'room.update']
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/room-add.module').then(x => x.RoomAddModule),
    data: {
      name: 'room_add',
      breadcrumb: {
        icon: 'plus',
        title: 'add'
      },
      permissions: ['room.manage', 'room.create']
    }
  },
  {
    path: 'types',
    loadChildren: () => import('../type/list/room-type-list.module').then(x => x.RoomTypeListModule),
    data: {
      name: 'room_type_list',
      breadcrumb: {
        icon: 'plus',
        title: 'room.types'
      },
      permissions: ['room.type.manage', 'room.type.create']
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RoomListRoutingModule { }
