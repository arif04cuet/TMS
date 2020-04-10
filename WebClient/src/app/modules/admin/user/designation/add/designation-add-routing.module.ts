import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DesignationAddComponent } from './designation-add.component';

const routes: Routes = [
  { path: '', component: DesignationAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DesignationAddRoutingModule { }
