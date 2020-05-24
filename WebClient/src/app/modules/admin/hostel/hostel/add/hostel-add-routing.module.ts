import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HostelAddComponent } from './hostel-add.component';

const routes: Routes = [
  { path: '', component: HostelAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HostelAddRoutingModule { }
