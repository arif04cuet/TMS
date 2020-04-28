import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MemberAddComponent } from './member-add.component';
import { MemberAddRoutingModule } from './member-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { LibraryHttpService } from 'src/services/http/library-http.service';
import { UserHttpService } from 'src/services/http/user/user-http.service';
import { LibraryCardHttpService } from 'src/services/http/library-card-http.service';

@NgModule({
  declarations: [
    MemberAddComponent
  ],
  imports: [
    MemberAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [MemberAddComponent],
  providers: [
    UserHttpService,
    LibraryHttpService,
    CommonValidator,
    LibraryCardHttpService
  ]
})
export class MemberAddModule { }
