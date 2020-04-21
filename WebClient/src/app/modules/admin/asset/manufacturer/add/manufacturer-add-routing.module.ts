import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ManufacturerAddComponent } from './manufacturer-add.component';

const routes: Routes = [
  { path: '', component: ManufacturerAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ManufacturerAddRoutingModule { }
