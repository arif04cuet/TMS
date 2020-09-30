import { NgModule } from '@angular/core';

import { LibraryListComponent } from './library-list.component';
import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LibraryListRoutingModule } from './library-list-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { LibraryHttpService } from 'src/services/http/library-http.service';
import { TableActionsModule } from 'src/app/shared/table-actions.component';

@NgModule({
  declarations: [
    LibraryListComponent
  ],
  imports: [
    CommonModule,
    LibraryListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    TableActionsModule
  ],
  exports: [LibraryListComponent],
  providers: [
    LibraryHttpService
  ]
})
export class LibraryListModule { }
