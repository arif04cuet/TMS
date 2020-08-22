import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NgZorroAntdModule, NzModalService } from 'ng-zorro-antd';
import { SharedModule } from 'src/app/shared/shared.module';
import { AssetModalComponent } from './asset-modal.component';
import { AssetListModule } from './asset-list/asset-list.module';
import { LicenseListModule } from './license-list/license-list.module';
import { ConsumableListModule } from './consumable-list/consumable-list.module';

@NgModule({
  declarations: [
    AssetModalComponent
  ],
  imports: [
    CommonModule,
    NgZorroAntdModule,
    SharedModule,
    AssetListModule,
    LicenseListModule,
    ConsumableListModule
  ],
  exports: [AssetModalComponent],
  providers: [
    NzModalService
  ]
})
export class AssetModalModule { }
