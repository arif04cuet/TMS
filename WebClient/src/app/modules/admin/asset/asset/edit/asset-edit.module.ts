import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { RoleHttpService } from 'src/services/http/user/role-http.service';
import { CommonValidator } from 'src/validators/common.validator';
import { MediaHttpService } from 'src/services/http/media-http.service';
import { AssetEditComponent } from './asset-edit.component';
import { AssetEditRoutingModule } from './asset-edit-routing.module';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { AssetModelHttpService } from 'src/services/http/asset/asset-model-http.service';
import { StatusHttpService } from 'src/services/http/asset/status-http.service';
import { PhotoUploadModule } from 'src/app/shared/photo.component';
import { ViewModule } from 'src/app/shared/view.component';
import { DepreciationHttpService } from 'src/services/http/asset/depreciation-http.service';

@NgModule({
  declarations: [
    AssetEditComponent
  ],
  imports: [
    AssetEditRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectControlModule,
    PhotoUploadModule,
    ViewModule
  ],
  exports: [AssetEditComponent],
  providers: [
    RoleHttpService,
    CommonValidator,
    MediaHttpService,
    AssetModelHttpService,
    StatusHttpService,
    DepreciationHttpService
  ]
})
export class AssetEditModule { }
