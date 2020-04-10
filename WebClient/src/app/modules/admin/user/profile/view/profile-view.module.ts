import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UserHttpService } from 'src/services/http/user-http.service';
import { ProfileViewRoutingModule } from './profile-view-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { RoleHttpService } from 'src/services/http/role-http.service';
import { CommonHttpService } from 'src/services/http/common-http.service';
import { DesignationHttpService } from 'src/services/http/designation-http.service';
import { ProfileViewComponent } from './profile-view.component';

@NgModule({
  declarations: [
    ProfileViewComponent
  ],
  imports: [
    CommonModule,
    ProfileViewRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [ProfileViewComponent],
  providers: [
    UserHttpService,
    RoleHttpService,
    CommonHttpService,
    DesignationHttpService
  ]
})
export class ProfileViewModule { }
