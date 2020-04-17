import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RackAddComponent } from './rack-add.component';

const routes: Routes = [
  { path: '', component: RackAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RackAddRoutingModule { }
