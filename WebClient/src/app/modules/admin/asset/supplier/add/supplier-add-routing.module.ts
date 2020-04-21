import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SupplierAddComponent } from './supplier-add.component';

const routes: Routes = [
  { path: '', component: SupplierAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SupplierAddRoutingModule { }
