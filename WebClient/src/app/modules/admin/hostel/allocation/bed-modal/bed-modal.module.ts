import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule, NzModalService } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BedModalComponent } from './bed-modal.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { HostelHttpService } from 'src/services/http/hostel/hostel-http.service';
import { BedHttpService } from 'src/services/http/hostel/bed-http.service';
import { SelectModule } from 'src/app/shared/select/select.module';

@NgModule({
  declarations: [
    BedModalComponent
  ],
  imports: [
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectControlModule,
    SelectModule
  ],
  exports: [BedModalComponent],
  providers: [
    BedHttpService,
    HostelHttpService,
    NzModalService
  ]
})
export class BedModalModule { }
