import { NgModule } from '@angular/core';

import { UserListComponent } from './user-list.component';
import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UserHttpService } from 'src/services/http/user/user-http.service';
import { UserListRoutingModule } from './user-list-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { RoleHttpService } from 'src/services/http/user/role-http.service';
import { CommonHttpService } from 'src/services/http/common-http.service';
import { DesignationHttpService } from 'src/services/http/user/designation-http.service';
import { TableActionsModule } from 'src/app/shared/table-actions.component';

@NgModule({
  declarations: [
    UserListComponent
  ],
  imports: [
    CommonModule,
    UserListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    TableActionsModule
  ],
  exports: [UserListComponent],
  providers: [
    UserHttpService,
    RoleHttpService,
    CommonHttpService,
    DesignationHttpService
  ]
})
export class UserListModule { }
