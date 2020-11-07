import { Component, Input } from '@angular/core';
import { TableComponent } from 'src/shared/table.component';
import { HotelHttpService } from 'src/services/hotel-http-service';
import { LibraryHttpService } from 'src/services/library-http-service';


@Component({
  selector: 'app-book-search',
  templateUrl: './book-search.component.html',
  styleUrls: ['./book-search.component.css']
})
export class BookSearchComponent extends TableComponent {

  q = "";
  searchResult = [];
  noResult = false;



  constructor(
    private libraryHttpService: LibraryHttpService) {
    super(libraryHttpService);
  }

  ngOnInit(): void {
    this.loading = false;
  }

  search() {
    if (this.q.length > 0)
      this.getData();

  }

  getData() {
    this.loading = true;
    const search = `Search=Book.Title like ${this.q}&Search=StatusId eq 1`;
    this.subscribe(this.libraryHttpService.listBookItems(null, search),
      (res: any) => {

        this.items = res.data.items

        this.searchResult = [];

        for (let i = 0; i < this.items.length; i++) {
          const item = this.items[i];

          var existingItemIndex = this.searchResult.findIndex(function (x) { return x.title === item.title });

          if (existingItemIndex === -1) {
            this.searchResult.push(item);
          }


        }
        this.noResult = this.searchResult.length ? false : true;
        this.loading = false;

      }
    );
  }

}
