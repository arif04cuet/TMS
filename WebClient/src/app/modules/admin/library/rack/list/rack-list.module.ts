import { NgModule } from '@angular/core';

import { RackListComponent } from './rack-list.component';
import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RackListRoutingModule } from './rack-list-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { RackHttpService } from 'src/services/http/rack-http.service';
import { TableActionsModule } from 'src/app/shared/table-actions.component';

@NgModule({
  declarations: [
    RackListComponent
  ],
  imports: [
    CommonModule,
    RackListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    TableActionsModule
  ],
  exports: [RackListComponent],
  providers: [
    RackHttpService
  ]
})
export class RackListModule { }
