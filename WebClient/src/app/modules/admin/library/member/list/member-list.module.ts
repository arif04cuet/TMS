import { NgModule } from '@angular/core';

import { MemberListComponent } from './member-list.component';
import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MemberListRoutingModule } from './member-list-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonHttpService } from 'src/services/http/common-http.service';
import { LibraryMemberHttpService } from 'src/services/http/library-member-http.service';
import { LibraryHttpService } from 'src/services/http/library-http.service';
import { TableActionsModule } from 'src/app/shared/table-actions.component';

@NgModule({
  declarations: [
    MemberListComponent
  ],
  imports: [
    CommonModule,
    MemberListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    TableActionsModule
  ],
  exports: [MemberListComponent],
  providers: [
    LibraryMemberHttpService,
    LibraryHttpService,
    CommonHttpService,
  ]
})
export class MemberListModule { }
