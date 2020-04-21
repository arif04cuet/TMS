import { NgModule } from '@angular/core';

import { ManufacturerListComponent } from './manufacturer-list.component';
import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ManufacturerListRoutingModule } from './manufacturer-list-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { ManufacturerHttpService } from 'src/services/http/asset/manufacturer-http.service';
import { CommonHttpService } from 'src/services/http/common-http.service';

@NgModule({
  declarations: [
    ManufacturerListComponent
  ],
  imports: [
    CommonModule,
    ManufacturerListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [ManufacturerListComponent],
  providers: [
    ManufacturerHttpService,
    CommonHttpService,
  ]
})
export class ManufacturerListModule { }
