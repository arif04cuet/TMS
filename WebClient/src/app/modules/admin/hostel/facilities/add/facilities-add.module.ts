import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FacilitiesAddComponent } from './facilities-add.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { FacilitiesAddRoutingModule } from './facilities-add-routing.module';
import { FacilitiesHttpService } from 'src/services/http/hostel/facilities-http.service';

@NgModule({
  declarations: [
    FacilitiesAddComponent
  ],
  imports: [
    FacilitiesAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [FacilitiesAddComponent],
  providers: [
    FacilitiesHttpService,
    CommonValidator
  ]
})
export class FacilitiesAddModule { }
