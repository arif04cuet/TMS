import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SubjectAddComponent } from './subject-add.component';
import { SubjectAddRoutingModule } from './subject-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { SubjectHttpService } from 'src/services/http/subject-http.service';

@NgModule({
  declarations: [
    SubjectAddComponent
  ],
  imports: [
    SubjectAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [SubjectAddComponent],
  providers: [
    SubjectHttpService,
    CommonValidator
  ]
})
export class SubjectAddModule { }
