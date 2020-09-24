import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { FacilitiesListComponent } from './facilities-list.component';
import { FacilitiesListRoutingModule } from './facilities-list-routing.module';
import { FacilitiesHttpService } from 'src/services/http/hostel/facilities-http.service';
import { CommonValidator } from 'src/validators/common.validator';

@NgModule({
  declarations: [
    FacilitiesListComponent
  ],
  imports: [
    CommonModule,
    FacilitiesListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [FacilitiesListComponent],
  providers: [
    FacilitiesHttpService,
    CommonValidator
  ]
})
export class FacilitiesListModule { }
