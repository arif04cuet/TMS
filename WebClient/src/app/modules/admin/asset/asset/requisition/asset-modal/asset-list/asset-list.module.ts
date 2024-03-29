import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { AssetListComponent } from './asset-list.component';
import { AssetBaseHttpService } from 'src/services/http/asset/asset-http-service';


@NgModule({
  declarations: [
    AssetListComponent
  ],
  imports: [
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [AssetListComponent],
  providers: [
    AssetBaseHttpService
  ]
})
export class AssetListModule { }
