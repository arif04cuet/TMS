import { NgModule } from '@angular/core';

import { SubjectListComponent } from './subject-list.component';
import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SubjectListRoutingModule } from './subject-list-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { SubjectHttpService } from 'src/services/http/subject-http.service';
import { CommonValidator } from 'src/validators/common.validator';

@NgModule({
  declarations: [
    SubjectListComponent
  ],
  imports: [
    CommonModule,
    SubjectListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [SubjectListComponent],
  providers: [
   SubjectHttpService,
   CommonValidator
  ]
})
export class SubjectListModule { }
