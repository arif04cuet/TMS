import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProfileViewComponent } from './profile-view.component';

const routes: Routes = [
  { path: '', component: ProfileViewComponent },
  {
    path: 'edit',
    loadChildren: () => import('../add/profile-add.module').then(x => x.ProfileAddModule),
    data: { name: 'profile_edit' }
  },
  {
    path: 'add',
    loadChildren: () => import('../add/profile-add.module').then(x => x.ProfileAddModule),
    data: { name: 'profile_add' }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProfileViewRoutingModule { }
