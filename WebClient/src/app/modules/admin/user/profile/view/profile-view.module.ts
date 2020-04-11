import { NgModule } from '@angular/core';

import { CommonModule, DatePipe } from '@angular/common';
import { NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UserHttpService } from 'src/services/http/user-http.service';
import { ProfileViewRoutingModule } from './profile-view-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { ProfileViewComponent } from './profile-view.component';
import { AuthService } from 'src/services/auth.service';
import { TimeAgoPipe } from 'src/pipes/time-ago.pipe';

@NgModule({
  declarations: [
    ProfileViewComponent
  ],
  imports: [
    CommonModule,
    ProfileViewRoutingModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [ProfileViewComponent],
  providers: [
    UserHttpService,
    AuthService,
    DatePipe,
    TimeAgoPipe
  ]
})
export class ProfileViewModule { }
