import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { AssetModelListComponent } from './asset-model-list.component';
import { AssetModelListRoutingModule } from './asset-model-list-routing.module';
import { AssetModelHttpService } from 'src/services/http/asset/asset-model-http.service';
import { TableActionsModule } from 'src/app/shared/table-actions.component';


@NgModule({
  declarations: [
    AssetModelListComponent
  ],
  imports: [
    CommonModule,
    AssetModelListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    TableActionsModule
  ],
  exports: [AssetModelListComponent],
  providers: [
    AssetModelHttpService
  ]
})
export class AssetModelListModule { }
