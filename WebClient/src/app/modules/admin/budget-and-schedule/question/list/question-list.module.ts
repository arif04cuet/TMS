import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { QuestionHttpService } from 'src/services/http/budget-and-schedule/question-http.service';
import { QuestionListComponent } from './question-list.component';
import { QuestionListRoutingModule } from './question-list-routing.module';
import { TableActionsModule } from 'src/app/shared/table-actions.component';

@NgModule({
  declarations: [
    QuestionListComponent
  ],
  imports: [
    CommonModule,
    QuestionListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    TableActionsModule
  ],
  exports: [QuestionListComponent],
  providers: [
    QuestionHttpService
  ]
})
export class QuestionListModule { }