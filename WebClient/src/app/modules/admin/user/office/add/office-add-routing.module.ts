import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OfficeAddComponent } from './office-add.component';

const routes: Routes = [
  { path: '', component: OfficeAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OfficeAddRoutingModule { }
