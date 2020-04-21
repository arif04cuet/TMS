import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DepreciationAddComponent } from './depreciation-add.component';

const routes: Routes = [
  { path: '', component: DepreciationAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DepreciationAddRoutingModule { }
