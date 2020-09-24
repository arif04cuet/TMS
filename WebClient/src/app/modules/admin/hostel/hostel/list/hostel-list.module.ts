import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { HostelListComponent } from './hostel-list.component';
import { HostelListRoutingModule } from './hostel-list-routing.module';
import { HostelHttpService } from 'src/services/http/hostel/hostel-http.service';
import { CommonValidator } from 'src/validators/common.validator';

@NgModule({
  declarations: [
    HostelListComponent
  ],
  imports: [
    CommonModule,
    HostelListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [HostelListComponent],
  providers: [
    HostelHttpService,
    CommonValidator
  ]
})
export class HostelListModule { }
