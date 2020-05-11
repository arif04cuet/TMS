import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AssetViewComponent } from './asset-view.component';

const routes: Routes = [
  { path: '', component: AssetViewComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AssetViewRoutingModule { }
