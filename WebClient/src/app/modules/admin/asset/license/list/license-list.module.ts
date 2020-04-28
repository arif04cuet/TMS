import { NgModule } from '@angular/core';

import { LicenseListComponent } from './license-list.component';
import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LicenseListRoutingModule } from './license-list-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { LicenseHttpService } from 'src/services/http/asset/license-http.service';


@NgModule({
  declarations: [
    LicenseListComponent
  ],
  imports: [
    CommonModule,
    LicenseListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [LicenseListComponent],
  providers: [
    LicenseHttpService
  ]
})
export class LicenseListModule { }
