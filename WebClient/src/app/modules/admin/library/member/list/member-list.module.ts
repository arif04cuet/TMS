import { NgModule } from '@angular/core';

import { MemberListComponent } from './member-list.component';
import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UserHttpService } from 'src/services/http/user-http.service';
import { MemberListRoutingModule } from './member-list-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { RoleHttpService } from 'src/services/http/role-http.service';
import { CommonHttpService } from 'src/services/http/common-http.service';
import { DesignationHttpService } from 'src/services/http/designation-http.service';

@NgModule({
  declarations: [
    MemberListComponent
  ],
  imports: [
    CommonModule,
    MemberListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [MemberListComponent],
  providers: [
    UserHttpService,
    RoleHttpService,
    CommonHttpService,
    DesignationHttpService
  ]
})
export class MemberListModule { }
