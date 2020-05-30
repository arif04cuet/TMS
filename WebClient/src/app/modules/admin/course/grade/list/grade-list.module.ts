import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { FacilitiesHttpService } from 'src/services/http/hostel/facilities-http.service';
import { GradeListComponent } from './grade-list.component';
import { GradeListRoutingModule } from './grade-list-routing.module';

@NgModule({
  declarations: [
    GradeListComponent
  ],
  imports: [
    CommonModule,
    GradeListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [GradeListComponent],
  providers: [
    FacilitiesHttpService
  ]
})
export class GradeListModule { }
