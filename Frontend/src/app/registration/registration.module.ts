import { NgModule } from '@angular/core';
import { RegistrationComponent } from './registration.component';
import { NzTableModule, NzAlertModule, NzFormModule, NzInputModule, NzButtonModule, NzTagModule } from 'ng-zorro-antd';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ScrollingModule } from '@angular/cdk/scrolling';
import { SelectControlModule } from 'src/shared/select-control/select-control.module';
import { AuthService } from 'src/services/auth.service';
import { RegistrationHttpService } from 'src/services/registration-http-service';

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
    SelectControlModule,
    NzAlertModule,
    NzTableModule
  ],
  providers: [
    RegistrationHttpService,
    AuthService
  ]
})
export class RegistrationModule { }
