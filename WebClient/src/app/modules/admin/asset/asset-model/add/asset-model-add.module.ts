import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { RoleHttpService } from 'src/services/http/user/role-http.service';
import { CommonValidator } from 'src/validators/common.validator';
import { MediaHttpService } from 'src/services/http/media-http.service';
import { AssetModelAddComponent } from './asset-model-add.component';
import { AssetModelAddRoutingModule } from './asset-model-add-routing.module';

@NgModule({
  declarations: [
    AssetModelAddComponent
  ],
  imports: [
    AssetModelAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [AssetModelAddComponent],
  providers: [
    RoleHttpService,
    CommonValidator,
    MediaHttpService
  ]
})
export class AssetModelAddModule { }
