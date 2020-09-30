import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { ResourcePersonListComponent } from './resource-person-list.component';
import { ResourcePersonRoutingModule } from './resource-person-list-routing.module';
import { ResourcePersonHttpService } from 'src/services/http/course/resource-person-http.service';
import { TableActionsModule } from 'src/app/shared/table-actions.component';

@NgModule({
  declarations: [
    ResourcePersonListComponent
  ],
  imports: [
    CommonModule,
    ResourcePersonRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    TableActionsModule
  ],
  exports: [ResourcePersonListComponent],
  providers: [
    ResourcePersonHttpService
  ]
})
export class ResourcePersonListModule { }
