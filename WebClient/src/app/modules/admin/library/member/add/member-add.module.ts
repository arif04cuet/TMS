import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MemberAddComponent } from './member-add.component';
import { MemberAddRoutingModule } from './member-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonHttpService } from 'src/services/http/common-http.service';
import { CommonValidator } from 'src/validators/common.validator';
import { PermissionModule } from '../../../user/permission/permission.module';
import { LibraryHttpService } from 'src/services/http/library-http.service';
import { LibraryCardHttpService } from 'src/services/http/library-card-http.service';

@NgModule({
  declarations: [
    MemberAddComponent
  ],
  imports: [
    MemberAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    PermissionModule
  ],
  exports: [MemberAddComponent],
  providers: [
    CommonHttpService,
    LibraryHttpService,
    CommonValidator,
    LibraryCardHttpService
  ]
})
export class MemberAddModule { }
