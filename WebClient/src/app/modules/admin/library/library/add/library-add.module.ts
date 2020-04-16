import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LibraryAddComponent } from './library-add.component';
import { UserHttpService } from 'src/services/http/user-http.service';
import { LibraryAddRoutingModule } from './library-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { LibraryHttpService } from 'src/services/http/library-http.service';

@NgModule({
  declarations: [
    LibraryAddComponent
  ],
  imports: [
    LibraryAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [LibraryAddComponent],
  providers: [
    UserHttpService,
    LibraryHttpService,
    CommonValidator
  ]
})
export class LibraryAddModule { }
