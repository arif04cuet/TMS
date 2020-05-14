import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { AssetActivityLogRoutingModule } from './asset-activity-log-routing.module';
import { AssetActivityLogComponent } from './asset-activity-log.component';
import { AssetReportsHttpService } from 'src/services/http/asset/asset-reports-http.service';


@NgModule({
  declarations: [
    AssetActivityLogComponent
  ],
  imports: [
    CommonModule,
    AssetActivityLogRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [AssetActivityLogComponent],
  providers: [
    AssetReportsHttpService
  ]
})
export class AssetActivityLogModule { }
