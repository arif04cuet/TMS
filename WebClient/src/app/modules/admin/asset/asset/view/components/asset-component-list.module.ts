import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { AssetComponentListRoutingModule } from './asset-component-list-routing.module';
import { AssetComponentListComponent } from './asset-component-list.component';
import { AssetBaseHttpService } from 'src/services/http/asset/asset-http-service';


@NgModule({
  declarations: [
    AssetComponentListComponent
  ],
  imports: [
    CommonModule,
    AssetComponentListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [AssetComponentListComponent],
  providers: [
    AssetBaseHttpService
  ]
})
export class AssetComponentListModule { }
