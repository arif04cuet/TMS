import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AssetViewComponent } from './asset-view.component';
import { AssetViewRoutingModule } from './asset-view-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { AssetDetailsModule } from './details/asset-details.module';
import { AssetCheckoutHistoryModule } from './history/asset-checkout-history.module';
import { AssetComponentListModule } from './components/asset-component-list.module';
import { AssetMaintenanceAddModule } from './maintenance/add/asset-maintenance-add.module';
import { AssetMaintenanceListModule } from './maintenance/list/asset-maintenance-list.module';


@NgModule({
  declarations: [
    AssetViewComponent
  ],
  imports: [
    AssetViewRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectControlModule,
    AssetDetailsModule,
    AssetCheckoutHistoryModule,
    AssetComponentListModule,
    AssetMaintenanceListModule
  ],
  exports: [AssetViewComponent]
})
export class AssetViewModule { }
