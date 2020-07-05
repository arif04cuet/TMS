import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { ExamAddModule } from '../add/exam-add.module';
import { ExamListModule } from '../list/exam-list.module';
import { ExamHomeComponent } from './exam-home.component';
import { ResultAddModule } from '../result/result-add.module';

@NgModule({
  declarations: [
    ExamHomeComponent
  ],
  imports: [
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    ExamAddModule,
    ExamListModule,
    ResultAddModule
  ],
  exports: [ExamHomeComponent]
})
export class ExamHomeModule { }