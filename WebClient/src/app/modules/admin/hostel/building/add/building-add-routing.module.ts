import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BuildingAddComponent } from './building-add.component';

const routes: Routes = [
  { path: '', component: BuildingAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BuildingAddRoutingModule { }
