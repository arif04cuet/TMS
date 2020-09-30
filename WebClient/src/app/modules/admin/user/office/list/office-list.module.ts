import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { OfficeHttpService } from 'src/services/http/user/office-http.service';
import { OfficeListComponent } from './office-list.component';
import { OfficeListRoutingModule } from './office-list-routing.module';
import { TableActionsModule } from 'src/app/shared/table-actions.component';

@NgModule({
  declarations: [
    OfficeListComponent
  ],
  imports: [
    CommonModule,
    OfficeListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    TableActionsModule
  ],
  exports: [OfficeListComponent],
  providers: [
    OfficeHttpService
  ]
})
export class OfficeListModule { }
