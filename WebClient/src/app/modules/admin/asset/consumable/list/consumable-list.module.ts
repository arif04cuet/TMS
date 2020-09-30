import { NgModule } from '@angular/core';

import { ConsumableListComponent } from './consumable-list.component';
import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { ConsumableListRoutingModule } from './consumable-list-routing.module';
import { ConsumableHttpService } from 'src/services/http/asset/consumable-http.service';
import { TableActionsModule } from 'src/app/shared/table-actions.component';


@NgModule({
  declarations: [
    ConsumableListComponent
  ],
  imports: [
    CommonModule,
    ConsumableListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    TableActionsModule
  ],
  exports: [ConsumableListComponent],
  providers: [
    ConsumableHttpService
  ]
})
export class ConsumableListModule { }
