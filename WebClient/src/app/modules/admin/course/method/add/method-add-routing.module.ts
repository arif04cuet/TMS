import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MethodAddComponent } from './method-add.component';

const routes: Routes = [
  { path: '', component: MethodAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MethodAddRoutingModule { }
