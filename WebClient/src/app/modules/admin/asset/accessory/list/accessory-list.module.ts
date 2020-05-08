import { NgModule } from '@angular/core';

import { AccessoryListComponent } from './accessory-list.component';
import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AccessoryListRoutingModule } from './accessory-list-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { AccessoryHttpService } from 'src/services/http/asset/accessory-http.service';


@NgModule({
  declarations: [
    AccessoryListComponent
  ],
  imports: [
    CommonModule,
    AccessoryListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [AccessoryListComponent],
  providers: [
    AccessoryHttpService
  ]
})
export class AccessoryListModule { }
