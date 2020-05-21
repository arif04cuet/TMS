import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MemberRequestComponent } from './member-request.component';

const routes: Routes = [
  { path: '', component: MemberRequestComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MemberRequestRoutingModule { }
