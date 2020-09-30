import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { HonorariumHeadListComponent } from './honorarium-head-list.component';
import { HonorariumHeadListRoutingModule } from './honorarium-head-list-routing.module';
import { HonorariumHeadHttpService } from 'src/services/http/budget-and-schedule/honorarium-head-http.service';
import { TableActionsModule } from 'src/app/shared/table-actions.component';

@NgModule({
  declarations: [
    HonorariumHeadListComponent
  ],
  imports: [
    CommonModule,
    HonorariumHeadListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    TableActionsModule
  ],
  exports: [HonorariumHeadListComponent],
  providers: [
    HonorariumHeadHttpService
  ]
})
export class HonorariumHeadListModule { }
