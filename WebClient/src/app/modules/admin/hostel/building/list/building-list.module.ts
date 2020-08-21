import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { BuildingListComponent } from './building-list.component';
import { BuildingListRoutingModule } from './building-list-routing.module';
import { BuildingHttpService } from 'src/services/http/hostel/building-http.service';
import { HostelHttpService } from 'src/services/http/hostel/hostel-http.service';

@NgModule({
  declarations: [
    BuildingListComponent
  ],
  imports: [
    CommonModule,
    BuildingListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [BuildingListComponent],
  providers: [
    BuildingHttpService,
    HostelHttpService
  ]
})
export class BuildingListModule { }
