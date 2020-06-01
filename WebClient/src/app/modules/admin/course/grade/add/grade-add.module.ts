import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { GradeAddComponent } from './grade-add.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { GradeAddRoutingModule } from './grade-add-routing.module';
import { GradeHttpService } from 'src/services/http/course/grades-http.service';

@NgModule({
  declarations: [
    GradeAddComponent
  ],
  imports: [
    GradeAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [GradeAddComponent],
  providers: [
    GradeHttpService,
    CommonValidator
  ]
})
export class GradeAddModule { }
