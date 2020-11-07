import { NgModule } from '@angular/core';
import { LibraryComponent } from './library.component';
import { NzGridModule, NzIconModule, NzTableModule, NzButtonModule } from 'ng-zorro-antd';
import { CommonModule } from '@angular/common';
import { ContentListModule } from 'src/app/content-list/content-list.module';
import { LibraryHttpService } from 'src/services/library-http-service';
import { SharedModule } from 'src/shared/share.module';
import { BookSearchModule } from 'src/app/book-search/book-search.module';



@NgModule({
  declarations: [
    LibraryComponent
  ],
  exports: [LibraryComponent],
  imports: [
    CommonModule,
    NzGridModule,
    NzIconModule,
    NzTableModule,
    NzButtonModule,
    SharedModule,
    BookSearchModule
  ],
  providers: [
    LibraryHttpService
  ]
})
export class LibraryModule { }
