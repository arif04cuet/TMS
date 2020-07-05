import { NgModule } from '@angular/core';
import { LibraryMemberRegistrationComponent } from './library-member-registration.component';
import { LibraryHttpService } from 'src/services/library-http-service';
import { NzFormModule, NzInputModule, NzSelectModule, NzButtonModule } from 'ng-zorro-antd';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ScrollingModule } from '@angular/cdk/scrolling';

@NgModule({
  declarations: [
    LibraryMemberRegistrationComponent
  ],
  exports: [LibraryMemberRegistrationComponent],
  imports: [
    CommonModule,
    NzButtonModule,
    ScrollingModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NzInputModule,
    NzSelectModule
  ],
  providers: [
    LibraryHttpService
  ]
})
export class LibraryMemberRegistrationModule { }