import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { ExpertiseListComponent } from './expertise-list.component';
import { ExpertiseListRoutingModule } from './expertise-list-routing.module';
import { ExpertiseHttpService } from 'src/services/http/course/expertise-http.service';

@NgModule({
  declarations: [
    ExpertiseListComponent
  ],
  imports: [
    CommonModule,
    ExpertiseListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [ExpertiseListComponent],
  providers: [
    ExpertiseHttpService
  ]
})
export class ExpertiseListModule { }
