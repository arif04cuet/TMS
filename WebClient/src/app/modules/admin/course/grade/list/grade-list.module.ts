import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { GradeListComponent } from './grade-list.component';
import { GradeListRoutingModule } from './grade-list-routing.module';
import { GradeHttpService } from 'src/services/http/course/grades-http.service';

@NgModule({
  declarations: [
    GradeListComponent
  ],
  imports: [
    CommonModule,
    GradeListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [GradeListComponent],
  providers: [
    GradeHttpService
  ]
})
export class GradeListModule { }
