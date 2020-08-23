import { NgModule } from '@angular/core';

import { ConsumableListComponent } from './consumable-list.component';
import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { ConsumableHttpService } from 'src/services/http/asset/consumable-http.service';


@NgModule({
  declarations: [
    ConsumableListComponent
  ],
  imports: [
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [ConsumableListComponent],
  providers: [
    ConsumableHttpService
  ]
})
export class ConsumableListModule { }
