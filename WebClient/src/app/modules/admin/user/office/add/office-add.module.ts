import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { OfficeAddComponent } from './office-add.component';
import { OfficeAddRoutingModule } from './office-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { OfficeHttpService } from 'src/services/http/user/office-http.service';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { CommonHttpService } from 'src/services/http/common-http.service';
import { SelectModule } from 'src/app/shared/select/select.module';

@NgModule({
  declarations: [
    OfficeAddComponent
  ],
  imports: [
    OfficeAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectControlModule,
    SelectModule
  ],
  exports: [OfficeAddComponent],
  providers: [
    OfficeHttpService,
    CommonValidator,
    CommonHttpService
  ]
})
export class OfficeAddModule { }
