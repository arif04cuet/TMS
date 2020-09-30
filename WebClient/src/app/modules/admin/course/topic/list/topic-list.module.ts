import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { TopicListComponent } from './topic-list.component';
import { TopicListRoutingModule } from './topic-list-routing.module';
import { TopicHttpService } from 'src/services/http/course/topic-http.service';
import { TableActionsModule } from 'src/app/shared/table-actions.component';

@NgModule({
  declarations: [
    TopicListComponent
  ],
  imports: [
    CommonModule,
    TopicListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    TableActionsModule
  ],
  exports: [TopicListComponent],
  providers: [
    TopicHttpService
  ]
})
export class TopicListModule { }
