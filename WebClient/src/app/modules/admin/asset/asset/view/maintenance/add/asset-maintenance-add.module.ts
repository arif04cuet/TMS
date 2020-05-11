import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AssetMaintenanceAddRoutingModule } from './asset-maintenance-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { AssetMaintenanceHttpService } from 'src/services/http/asset/asset-maintenance-http.service';
import { AssetMaintenanceAddComponent } from './asset-maintenance-add.component';
import { AssetBaseHttpService } from 'src/services/http/asset/asset-http-service';

@NgModule({
  declarations: [
    AssetMaintenanceAddComponent
  ],
  imports: [
    AssetMaintenanceAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectControlModule
  ],
  exports: [AssetMaintenanceAddComponent],
  providers: [
    CommonValidator,
    AssetMaintenanceHttpService,
    AssetBaseHttpService
  ]
})
export class AssetMaintenanceAddModule { }
