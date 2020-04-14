import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { VendorAddComponent } from './vendor-add.component';
import { VendorAddRoutingModule } from './vendor-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { RoleHttpService } from 'src/services/http/role-http.service';
import { CommonValidator } from 'src/validators/common.validator';
import { CommonHttpService } from 'src/services/http/common-http.service';

@NgModule({
  declarations: [
    VendorAddComponent
  ],
  imports: [
    VendorAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [VendorAddComponent],
  providers: [
    RoleHttpService,
    CommonValidator,
    CommonHttpService
  ]
})
export class VendorAddModule { }
