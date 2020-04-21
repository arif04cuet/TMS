import { NgModule } from '@angular/core';

import { LocationListComponent } from './location-list.component';
import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LocationListRoutingModule } from './location-list-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { LocationHttpService } from 'src/services/http/asset/location-http.service';

@NgModule({
  declarations: [
    LocationListComponent
  ],
  imports: [
    CommonModule,
    LocationListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [LocationListComponent],
  providers: [
    LocationHttpService
  ]
})
export class LocationListModule { }
