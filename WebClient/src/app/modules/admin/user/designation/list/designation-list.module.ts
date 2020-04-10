import { NgModule } from '@angular/core';

import { DesignationListComponent } from './designation-list.component';
import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DesignationListRoutingModule } from './designation-list-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { DesignationHttpService } from 'src/services/http/designation-http.service';

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
    SharedModule
  ],
  exports: [DesignationListComponent],
  providers: [
    DesignationHttpService
  ]
})
export class DesignationListModule { }
