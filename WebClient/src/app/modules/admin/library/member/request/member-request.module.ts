import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { PermissionModule } from '../../../user/permission/permission.module';
import { LibraryHttpService } from 'src/services/http/library-http.service';
import { MemberRequestComponent } from './member-request.component';
import { MemberRequestRoutingModule } from './member-request-routing.module';

@NgModule({
  declarations: [
    MemberRequestComponent
  ],
  imports: [
    MemberRequestRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    PermissionModule
  ],
  exports: [MemberRequestComponent],
  providers: [
    LibraryHttpService,
    CommonValidator
  ]
})
export class MemberRequestModule { }
