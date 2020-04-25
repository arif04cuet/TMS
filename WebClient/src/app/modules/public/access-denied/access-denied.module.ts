import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import {  NgZorroAntdModule } from 'ng-zorro-antd';
import { AccessDeniedComponent } from './access-denied.component';
import { AccessDeniedRoutingModule } from './access-denied-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [
    AccessDeniedComponent
  ],
  imports: [
    AccessDeniedRoutingModule,
    CommonModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [AccessDeniedComponent],
})
export class AccessDeniedModule { }
