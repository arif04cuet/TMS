import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { ComponentHttpService } from 'src/services/http/asset/component-http.service';
import { ComponentListComponent } from './component-list.component';
import { ComponentListRoutingModule } from './component-list-routing.module';


@NgModule({
  declarations: [
    ComponentListComponent
  ],
  imports: [
    CommonModule,
    ComponentListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [ComponentListComponent],
  providers: [
    ComponentHttpService
  ]
})
export class ComponentListModule { }
