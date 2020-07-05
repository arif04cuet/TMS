import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { SessionProgressComponent } from './session-progress.component';
import { SessionProgressHttpService } from 'src/services/http/budget-and-schedule/session-progress-http.service';

@NgModule({
  declarations: [
    SessionProgressComponent
  ],
  imports: [
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [SessionProgressComponent],
  providers: [
    SessionProgressHttpService
  ]
})
export class SessionProgressModule { }