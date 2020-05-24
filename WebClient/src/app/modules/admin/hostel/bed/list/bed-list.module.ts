import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { BedHttpService } from 'src/services/http/hostel/bed-http.service';
import { BedListComponent } from './bed-list.component';
import { BedListRoutingModule } from './bed-list-routing.module';

@NgModule({
  declarations: [
    BedListComponent
  ],
  imports: [
    CommonModule,
    BedListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [BedListComponent],
  providers: [
    BedHttpService
  ]
})
export class BedListModule { }
