import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AssetCheckinRoutingModule } from './asset-checkin-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { AssetCheckinComponent } from './asset-checkin.component';
import { ViewModule } from 'src/app/shared/view.component';
import { CommonValidator } from 'src/validators/common.validator';
import { AssetBaseHttpService } from 'src/services/http/asset/asset-http-service';
import { StatusHttpService } from 'src/services/http/asset/status-http.service';

@NgModule({
  declarations: [
    AssetCheckinComponent
  ],
  imports: [
    AssetCheckinRoutingModule,
    CommonModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectControlModule,
    ViewModule
  ],
  exports: [AssetCheckinComponent],
  providers: [
    CommonValidator,
    AssetBaseHttpService,
    StatusHttpService
  ]
})
export class AssetCheckinModule { }
