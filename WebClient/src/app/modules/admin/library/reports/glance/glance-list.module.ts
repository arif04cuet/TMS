import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { LibraryReportHttpService } from 'src/services/http/library-report-http.service';
import { GlanceListComponent } from './glance-list.component';
import { GlanceListRoutingModule } from './glance-list-routing.module';

@NgModule({
  declarations: [
    GlanceListComponent
  ],
  imports: [
    CommonModule,
    GlanceListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [GlanceListComponent],
  providers: [
    LibraryReportHttpService
  ]
})
export class GlanceListModule { }
