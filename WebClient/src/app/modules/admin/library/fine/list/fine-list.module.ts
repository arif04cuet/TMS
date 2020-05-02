import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { LibraryMemberHttpService } from 'src/services/http/library-member-http.service';
import { FineListComponent } from './fine-list.component';
import { FineListRoutingModule } from './fine-list-routing.module';
import { LibraryHttpService } from 'src/services/http/library-http.service';

@NgModule({
  declarations: [
    FineListComponent
  ],
  imports: [
    CommonModule,
    FineListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [FineListComponent],
  providers: [
    LibraryHttpService,
    LibraryMemberHttpService
  ]
})
export class FineListModule { }
