import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AssetActivityLogComponent } from './asset-activity-log.component';

const routes: Routes = [
  { path: '', component: AssetActivityLogComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AssetActivityLogRoutingModule { }
