import { NgModule } from '@angular/core';

import { RoleListComponent } from './role-list.component';
import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RoleListRoutingModule } from './role-list-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { RoleHttpService } from 'src/services/http/role-http.service';

@NgModule({
  declarations: [
    RoleListComponent
  ],
  imports: [
    CommonModule,
    RoleListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [RoleListComponent],
  providers: [
    RoleHttpService
  ]
})
export class RoleListModule { }
