import { NgModule } from '@angular/core';

import { DesignationListComponent } from './designation-list.component';
import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DesignationListRoutingModule } from './designation-list-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { DesignationHttpService } from 'src/services/http/user/designation-http.service';
import { CommonValidator } from 'src/validators/common.validator';
import { TableActionsModule } from 'src/app/shared/table-actions.component';

@NgModule({
  declarations: [
    DesignationListComponent
  ],
  imports: [
    CommonModule,
    DesignationListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    TableActionsModule
  ],
  exports: [DesignationListComponent],
  providers: [
    DesignationHttpService,
    CommonValidator
  ]
})
export class DesignationListModule { }
