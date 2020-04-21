import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SupplierAddComponent } from './supplier-add.component';
import { SupplierAddRoutingModule } from './supplier-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { RoleHttpService } from 'src/services/http/role-http.service';
import { CommonValidator } from 'src/validators/common.validator';
import { CommonHttpService } from 'src/services/http/common-http.service';

@NgModule({
  declarations: [
    SupplierAddComponent
  ],
  imports: [
    SupplierAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [SupplierAddComponent],
  providers: [
    RoleHttpService,
    CommonValidator,
    CommonHttpService
  ]
})
export class SupplierAddModule { }
