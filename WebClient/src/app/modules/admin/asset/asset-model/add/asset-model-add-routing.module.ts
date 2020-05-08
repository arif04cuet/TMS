import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AssetModelAddComponent } from './asset-model-add.component';

const routes: Routes = [
  { path: '', component: AssetModelAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AssetModelAddRoutingModule { }
