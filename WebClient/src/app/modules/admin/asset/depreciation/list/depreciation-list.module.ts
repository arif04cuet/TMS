import { NgModule } from '@angular/core';

import { DepreciationListComponent } from './depreciation-list.component';
import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DepreciationListRoutingModule } from './depreciation-list-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { DepreciationHttpService } from 'src/services/http/asset/depreciation-http.service';
import { TableActionsModule } from 'src/app/shared/table-actions.component';


@NgModule({
  declarations: [
    DepreciationListComponent
  ],
  imports: [
    CommonModule,
    DepreciationListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    TableActionsModule
  ],
  exports: [DepreciationListComponent],
  providers: [
    DepreciationHttpService
  ]
})
export class DepreciationListModule { }
