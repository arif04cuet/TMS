import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BuildingAddComponent } from './building-add.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { BuildingAddRoutingModule } from './building-add-routing.module';
import { BuildingHttpService } from 'src/services/http/hostel/building-http.service';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { HostelHttpService } from 'src/services/http/hostel/hostel-http.service';

@NgModule({
  declarations: [
    BuildingAddComponent
  ],
  imports: [
    BuildingAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectControlModule
  ],
  exports: [BuildingAddComponent],
  providers: [
    BuildingHttpService,
    HostelHttpService,
    CommonValidator
  ]
})
export class BuildingAddModule { }
