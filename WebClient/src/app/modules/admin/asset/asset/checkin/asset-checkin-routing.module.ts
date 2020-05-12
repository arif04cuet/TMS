import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AssetCheckinComponent } from './asset-checkin.component';

const routes: Routes = [
  { path: '', component: AssetCheckinComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AssetCheckinRoutingModule { }
