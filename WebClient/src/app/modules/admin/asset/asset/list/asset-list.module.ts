import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { AssetModelHttpService } from 'src/services/http/asset/asset-model-http.service';
import { AssetListComponent } from './asset-list.component';
import { AssetListRoutingModule } from './asset-list-routing.module';


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
    SharedModule
  ],
  exports: [AssetListComponent],
  providers: [
    AssetModelHttpService
  ]
})
export class AssetListModule { }
