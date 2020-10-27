import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { LibraryReportHttpService } from 'src/services/http/library-report-http.service';
import { LostListComponent } from './lost-list.component';
import { LostListRoutingModule } from './lost-list-routing.module';

@NgModule({
  declarations: [
    LostListComponent
  ],
  imports: [
    CommonModule,
    LostListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [LostListComponent],
  providers: [
    LibraryReportHttpService
  ]
})
export class LostListModule { }
