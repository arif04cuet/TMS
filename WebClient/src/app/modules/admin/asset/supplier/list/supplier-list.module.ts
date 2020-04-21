import { NgModule } from '@angular/core';

import { SupplierListComponent } from './supplier-list.component';
import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SupplierListRoutingModule } from './supplier-list-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { SupplierHttpService } from 'src/services/http/asset/supplier-http.service';
import { CommonHttpService } from 'src/services/http/common-http.service';

@NgModule({
  declarations: [
    SupplierListComponent
  ],
  imports: [
    CommonModule,
    SupplierListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [SupplierListComponent],
  providers: [
    SupplierHttpService,
    CommonHttpService,
  ]
})
export class SupplierListModule { }
