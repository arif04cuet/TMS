import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { AssetMaintenanceListRoutingModule } from './asset-maintenance-list-routing.module';
import { AssetMaintenanceListComponent } from './asset-maintenance-list.component';
import { AssetMaintenanceHttpService } from 'src/services/http/asset/asset-maintenance-http.service';
import { TableActionsModule } from 'src/app/shared/table-actions.component';


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
    SharedModule,
    TableActionsModule
  ],
  exports: [AssetMaintenanceListComponent],
  providers: [
    AssetMaintenanceHttpService
  ]
})
export class AssetMaintenanceListModule { }
