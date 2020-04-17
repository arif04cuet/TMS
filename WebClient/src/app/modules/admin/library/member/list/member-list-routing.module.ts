import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MemberListComponent } from './member-list.component';

const routes: Routes = [
  { path: '', component: MemberListComponent },
  {
    path: ':id/edit',
    loadChildren: () => import('../add/member-add.module').then(x => x.MemberAddModule),
    data: {
      name: 'library_member_edit',
      breadcrumb: {
        icon: 'edit',
        title: 'edit'
      }
    }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/member-add.module').then(x => x.MemberAddModule),
    data: {
      name: 'library_member_add',
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
export class MemberListRoutingModule { }
