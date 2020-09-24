import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DesignationAddComponent } from './designation-add.component';
import { DesignationAddRoutingModule } from './designation-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { RoleHttpService } from 'src/services/http/user/role-http.service';
import { CommonValidator } from 'src/validators/common.validator';
import { DesignationHttpService } from 'src/services/http/user/designation-http.service';

@NgModule({
  declarations: [
    DesignationAddComponent
  ],
  imports: [
    DesignationAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [DesignationAddComponent],
  providers: [
    RoleHttpService,
    CommonValidator
  ]
})
export class DesignationAddModule { }
