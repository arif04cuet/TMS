import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule, NzModalService } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { EvaluationMethodModalComponent } from './evaluation-method-modal.component';
import { EvaluationMethodHttpService } from 'src/services/http/course/evaluation-method-http.service';

@NgModule({
  declarations: [
    EvaluationMethodModalComponent
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
  exports: [EvaluationMethodModalComponent],
  providers: [
    EvaluationMethodHttpService,
    NzModalService
  ]
})
export class EvaluationMethodModalModule { }
