import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule, NzListModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DashboardComponent } from './dashboard.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { DashboardRoutingModule } from './dashboard-routing.module';
import { AdminHttpService } from 'src/services/http/admin-http.service';
import { ViewModule } from 'src/app/shared/view.component';

@NgModule({
  declarations: [
    DashboardComponent
  ],
  imports: [
    DashboardRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    ViewModule,
    NzListModule
  ],
  exports: [DashboardComponent],
  providers: [
    AdminHttpService
  ]
})
export class DashboardModule { }
