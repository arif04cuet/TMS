import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ManufacturerAddComponent } from './manufacturer-add.component';
import { ManufacturerAddRoutingModule } from './manufacturer-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { RoleHttpService } from 'src/services/http/user/role-http.service';
import { CommonValidator } from 'src/validators/common.validator';

@NgModule({
  declarations: [
    ManufacturerAddComponent
  ],
  imports: [
    ManufacturerAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [ManufacturerAddComponent],
  providers: [
    RoleHttpService,
    CommonValidator
  ]
})
export class ManufacturerAddModule { }
