import { NgModule } from '@angular/core';

import { StatusListComponent } from './status-list.component';
import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { StatusListRoutingModule } from './status-list-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { StatusHttpService } from 'src/services/http/asset/status-http.service';
import { TableActionsModule } from 'src/app/shared/table-actions.component';


@NgModule({
  declarations: [
    StatusListComponent
  ],
  imports: [
    CommonModule,
    StatusListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    TableActionsModule
  ],
  exports: [StatusListComponent],
  providers: [
    StatusHttpService
  ]
})
export class StatusListModule { }
