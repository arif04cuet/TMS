import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FacilitiesAddComponent } from './facilities-add.component';

const routes: Routes = [
  { path: '', component: FacilitiesAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FacilitiesAddRoutingModule { }
