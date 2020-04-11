import { NgModule } from '@angular/core';

import { CommonModule, DatePipe } from '@angular/common';
import { NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UserHttpService } from 'src/services/http/user-http.service';
import { SharedModule } from 'src/app/shared/shared.module';
import { AuthService } from 'src/services/auth.service';
import { PermissionComponent } from './permission.component';
import { PermissionRoutingModule } from './permission-routing.module';
import { PermissionHttpService } from 'src/services/http/permission-http.service';

@NgModule({
  declarations: [
    PermissionComponent
  ],
  imports: [
    CommonModule,
    PermissionRoutingModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [PermissionComponent],
  providers: [
    UserHttpService,
    AuthService,
    PermissionHttpService
  ]
})
export class PermissionModule { }
