import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NgZorroAntdModule } from 'ng-zorro-antd';
import { SharedModule } from 'src/app/shared/shared.module';
import { BatchScheduleGalleryComponent } from './batch-schedule-gallery.component';
import { BatchScheduleGalleryRoutingModule } from './batch-schedule-gallery-routing.module';
import { BatchScheduleGalleryHttpService } from 'src/services/http/budget-and-schedule/batch-schedule-gallery-http.service';

@NgModule({
  declarations: [
    BatchScheduleGalleryComponent
  ],
  imports: [
    BatchScheduleGalleryRoutingModule,
    CommonModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [BatchScheduleGalleryComponent],
  providers: [
    BatchScheduleGalleryHttpService
  ]
})
export class BatchScheduleGalleryModule { }
