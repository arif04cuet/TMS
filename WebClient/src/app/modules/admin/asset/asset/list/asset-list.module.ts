import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { AssetListComponent } from './asset-list.component';
import { AssetListRoutingModule } from './asset-list-routing.module';
import { AssetBaseHttpService } from 'src/services/http/asset/asset-http-service';
import { TableActionsModule } from 'src/app/shared/table-actions.component';


@NgModule({
  declarations: [
    AssetListComponent
  ],
  imports: [
    CommonModule,
    AssetListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    TableActionsModule
  ],
  exports: [AssetListComponent],
  providers: [
    AssetBaseHttpService
  ]
})
export class AssetListModule { }
