import { NgModule } from '@angular/core';
import { BookSearchComponent } from './book-search.component';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzCollapseModule } from 'ng-zorro-antd/collapse';
import { CommonModule } from '@angular/common';
import { HotelHttpService } from 'src/services/hotel-http-service';
import { NzButtonModule, NzDatePickerModule, NzTableModule, NzGridModule, NzSelectModule, NzInputModule, NzIconModule, NzCardModule } from 'ng-zorro-antd';
import { FormsModule } from '@angular/forms';
import { SharedModule } from 'src/shared/share.module';

@NgModule({
  declarations: [
    BookSearchComponent
  ],
  imports: [
    CommonModule,
    NzLayoutModule,
    NzCollapseModule,
    CommonModule,
    NzButtonModule,
    NzDatePickerModule,
    NzTableModule,
    FormsModule,
    NzGridModule,
    NzSelectModule,
    SharedModule,
    NzInputModule,
    NzIconModule,
    NzCardModule
  ],
  providers: [
    HotelHttpService
  ],
  exports: [BookSearchComponent]
})
export class BookSearchModule { }
