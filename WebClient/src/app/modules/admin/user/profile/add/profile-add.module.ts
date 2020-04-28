import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule, NzDatePickerModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProfileAddComponent } from './profile-add.component';
import { UserHttpService } from 'src/services/http/user/user-http.service';
import { ProfileAddRoutingModule } from './profile-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonHttpService } from 'src/services/http/common-http.service';
import { CommonValidator } from 'src/validators/common.validator';
import { AuthService } from 'src/services/auth.service';
import { MediaHttpService } from 'src/services/http/media-http.service';

@NgModule({
  declarations: [
    ProfileAddComponent
  ],
  imports: [
    ProfileAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    NzDatePickerModule
  ],
  exports: [ProfileAddComponent],
  providers: [
    UserHttpService,
    CommonHttpService,
    CommonValidator,
    AuthService,
    MediaHttpService
  ]
})
export class ProfileAddModule { }
