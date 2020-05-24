import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HostelAddComponent } from './hostel-add.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { HostelAddRoutingModule } from './hostel-add-routing.module';
import { HostelHttpService } from 'src/services/http/hostel/hostel-http.service';

@NgModule({
  declarations: [
    HostelAddComponent
  ],
  imports: [
    HostelAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [HostelAddComponent],
  providers: [
    HostelHttpService,
    CommonValidator
  ]
})
export class HostelAddModule { }
