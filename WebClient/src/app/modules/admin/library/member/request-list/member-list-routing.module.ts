import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MemberRequestListComponent } from './member-list.component';

const routes: Routes = [
  { path: '', component: MemberRequestListComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MemberRequestListRoutingModule { }
