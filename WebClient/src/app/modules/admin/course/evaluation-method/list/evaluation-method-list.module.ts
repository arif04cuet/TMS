import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { EvaluationMethodListComponent } from './evaluation-method-list.component';
import { EvaluationMethodListRoutingModule } from './evaluation-method-list-routing.module';
import { EvaluationMethodHttpService } from 'src/services/http/course/evaluation-method-http.service';

@NgModule({
  declarations: [
    EvaluationMethodListComponent
  ],
  imports: [
    CommonModule,
    EvaluationMethodListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [EvaluationMethodListComponent],
  providers: [
    EvaluationMethodHttpService
  ]
})
export class EvaluationMethodListModule { }
