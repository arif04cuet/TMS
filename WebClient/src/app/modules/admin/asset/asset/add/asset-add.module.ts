import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { RoleHttpService } from 'src/services/http/user/role-http.service';
import { CommonValidator } from 'src/validators/common.validator';
import { MediaHttpService } from 'src/services/http/media-http.service';
import { AssetAddComponent } from './asset-add.component';
import { AssetAddRoutingModule } from './asset-add-routing.module';

@NgModule({
  declarations: [
    AssetAddComponent
  ],
  imports: [
    AssetAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [AssetAddComponent],
  providers: [
    RoleHttpService,
    CommonValidator,
    MediaHttpService
  ]
})
export class AssetAddModule { }
