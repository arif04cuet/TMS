import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AssetAuditAddComponent } from './asset-audit-add.component';

const routes: Routes = [
  { path: '', component: AssetAuditAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AssetAuditAddRoutingModule { }
