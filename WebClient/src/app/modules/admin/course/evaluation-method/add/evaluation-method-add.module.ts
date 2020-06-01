import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { EvaluationMethodHttpService } from 'src/services/http/course/evaluation-method-http.service';
import { EvaluationMethodAddComponent } from './evaluation-method-add.component';
import { EvaluationMethodAddRoutingModule } from './evaluation-method-add-routing.module';

@NgModule({
  declarations: [
    EvaluationMethodAddComponent
  ],
  imports: [
    EvaluationMethodAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [EvaluationMethodAddComponent],
  providers: [
    EvaluationMethodHttpService,
    CommonValidator
  ]
})
export class EvaluationMethodAddModule { }
