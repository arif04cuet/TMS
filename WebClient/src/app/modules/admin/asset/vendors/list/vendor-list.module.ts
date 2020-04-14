import { NgModule } from '@angular/core';

import { VendorListComponent } from './vendor-list.component';
import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { VendorListRoutingModule } from './vendor-list-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { VendorHttpService } from 'src/services/http/vendor-http.service';
import { CommonHttpService } from 'src/services/http/common-http.service';

@NgModule({
  declarations: [
    VendorListComponent
  ],
  imports: [
    CommonModule,
    VendorListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [VendorListComponent],
  providers: [
    VendorHttpService,
    CommonHttpService,
  ]
})
export class VendorListModule { }
