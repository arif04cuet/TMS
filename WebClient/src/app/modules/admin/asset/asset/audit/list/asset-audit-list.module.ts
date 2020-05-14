import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { AssetAuditHttpService } from 'src/services/http/asset/asset-audit-http.service';
import { AssetMaintenanceListComponent } from '../../view/maintenance/list/asset-maintenance-list.component';
import { AssetMaintenanceListRoutingModule } from '../../view/maintenance/list/asset-maintenance-list-routing.module';


@NgModule({
  declarations: [
    AssetMaintenanceListComponent
  ],
  imports: [
    CommonModule,
    AssetMaintenanceListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [AssetMaintenanceListComponent],
  providers: [
    AssetAuditHttpService
  ]
})
export class AssetMaintenanceListModule { }
