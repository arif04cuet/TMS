import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StatusAddComponent } from './status-add.component';

const routes: Routes = [
  { path: '', component: StatusAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StatusAddRoutingModule { }
