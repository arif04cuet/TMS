import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule, NzModalService } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { TopicHttpService } from 'src/services/http/course/topic-http.service';
import { TopicsModalComponent } from './topics-modal.component';

@NgModule({
  declarations: [
    TopicsModalComponent
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
  exports: [TopicsModalComponent],
  providers: [
    TopicHttpService,
    NzModalService
  ]
})
export class TopicsModalModule { }
