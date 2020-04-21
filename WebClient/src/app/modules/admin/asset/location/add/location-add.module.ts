import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LocationAddComponent } from './location-add.component';
import { LocationAddRoutingModule } from './location-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { RoleHttpService } from 'src/services/http/role-http.service';
import { CommonValidator } from 'src/validators/common.validator';


@NgModule({
  declarations: [
    LocationAddComponent
  ],
  imports: [
    LocationAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [LocationAddComponent],
  providers: [
    RoleHttpService,
    CommonValidator
  ]
})
export class LocationAddModule { }
