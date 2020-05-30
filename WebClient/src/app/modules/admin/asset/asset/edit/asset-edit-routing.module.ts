import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AssetEditComponent } from './asset-edit.component';

const routes: Routes = [
  { path: '', component: AssetEditComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AssetEditRoutingModule { }
