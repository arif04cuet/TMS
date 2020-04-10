import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProfileAddComponent } from './profile-add.component';

const routes: Routes = [
  { path: '', component: ProfileAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProfileAddRoutingModule { }
