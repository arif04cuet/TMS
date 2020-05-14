import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AssetAuditLogComponent } from './asset-audit-log.component';

const routes: Routes = [
  { path: '', component: AssetAuditLogComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AssetAuditLogRoutingModule { }
