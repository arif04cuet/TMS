import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AssetComponentListComponent } from './asset-component-list.component';

const routes: Routes = [
  { path: '', component: AssetComponentListComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AssetComponentListRoutingModule { }
