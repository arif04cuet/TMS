import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ConsumableDetailsComponent } from './consumable-details.component';
import { ConsumableDetailsRoutingModule } from './consumable-details-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { ConsumableHttpService } from 'src/services/http/asset/consumable-http.service';


@NgModule({
  declarations: [
    ConsumableDetailsComponent
  ],
  imports: [
    ConsumableDetailsRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectControlModule
  ],
  exports: [ConsumableDetailsComponent],
  providers: [
    ConsumableHttpService
  ]
})
export class ConsumableDetailsModule { }
