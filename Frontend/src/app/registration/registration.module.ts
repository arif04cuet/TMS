import { NgModule } from '@angular/core';
import { RegistrationComponent } from './registration.component';
import { NzTableModule, NzAlertModule, NzFormModule, NzInputModule, NzButtonModule, NzTagModule, NzSelectModule, NzIconModule } from 'ng-zorro-antd';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ScrollingModule } from '@angular/cdk/scrolling';
import { AuthService } from 'src/services/auth.service';
import { RegistrationHttpService } from 'src/services/registration-http-service';
import { SharedModule } from 'src/shared/share.module';
import { MediaHttpService } from 'src/services/media-http.service';

@NgModule({
  declarations: [
    RegistrationComponent
  ],
  exports: [RegistrationComponent],
  imports: [
    CommonModule,
    NzButtonModule,
    ScrollingModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NzInputModule,
    NzTagModule,
    NzAlertModule,
    NzTableModule,
    NzSelectModule,
    SharedModule,
    NzIconModule
  ],
  providers: [
    RegistrationHttpService,
    AuthService,
    MediaHttpService
  ]
})
export class RegistrationModule { }
