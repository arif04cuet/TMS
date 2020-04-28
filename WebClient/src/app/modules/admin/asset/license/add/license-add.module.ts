import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LicenseAddComponent } from './license-add.component';
import { LicenseAddRoutingModule } from './license-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { RoleHttpService } from 'src/services/http/role-http.service';
import { CommonValidator } from 'src/validators/common.validator';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';

@NgModule({
  declarations: [
    LicenseAddComponent
  ],
  imports: [
    LicenseAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectControlModule
  ],
  exports: [LicenseAddComponent],
  providers: [
    RoleHttpService,
    CommonValidator
  ]
})
export class LicenseAddModule { }
