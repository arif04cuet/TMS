import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { SessionProgressHttpService } from 'src/services/http/budget-and-schedule/session-progress-http.service';
import { HonorariumComponent } from './honorarium.component';

@NgModule({
  declarations: [
    HonorariumComponent
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
  exports: [HonorariumComponent],
  providers: [
    SessionProgressHttpService
  ]
})
export class HonorariumModule { }