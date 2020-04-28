import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DepreciationAddComponent } from './depreciation-add.component';
import { DepreciationAddRoutingModule } from './depreciation-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { RoleHttpService } from 'src/services/http/user/role-http.service';
import { CommonValidator } from 'src/validators/common.validator';


@NgModule({
  declarations: [
    DepreciationAddComponent
  ],
  imports: [
    DepreciationAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [DepreciationAddComponent],
  providers: [
    RoleHttpService,
    CommonValidator
  ]
})
export class DepreciationAddModule { }
