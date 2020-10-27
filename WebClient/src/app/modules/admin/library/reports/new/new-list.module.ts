import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { LibraryReportHttpService } from 'src/services/http/library-report-http.service';
import { NewListComponent } from './new-list.component';
import { NewListRoutingModule } from './new-list-routing.module';

@NgModule({
  declarations: [
    NewListComponent
  ],
  imports: [
    CommonModule,
    NewListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [NewListComponent],
  providers: [
    LibraryReportHttpService
  ]
})
export class NewListModule { }
