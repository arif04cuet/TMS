import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RoleAddComponent } from './role-add.component';

const routes: Routes = [
  { path: '', component: RoleAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RoleAddRoutingModule { }
