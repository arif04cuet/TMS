import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { LibraryReportHttpService } from 'src/services/http/library-report-http.service';
import { EntryListRoutingModule } from './entry-list-routing.module';
import { EntryListComponent } from './entry-list.component';

@NgModule({
  declarations: [
    EntryListComponent
  ],
  imports: [
    CommonModule,
    EntryListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [EntryListComponent],
  providers: [
    LibraryReportHttpService
  ]
})
export class EntryListModule { }
