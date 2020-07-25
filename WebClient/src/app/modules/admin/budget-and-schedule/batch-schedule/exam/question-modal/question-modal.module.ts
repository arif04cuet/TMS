import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule, NzModalService } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { QuestionHttpService } from 'src/services/http/budget-and-schedule/question-http.service';
import { QuestionModalComponent } from './question-modal.component';

@NgModule({
  declarations: [
    QuestionModalComponent
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
  exports: [QuestionModalComponent],
  providers: [
    QuestionHttpService,
    NzModalService
  ]
})
export class QuestionModalModule { }
