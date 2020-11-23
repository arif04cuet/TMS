import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { forkJoin } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { BookHttpService } from 'src/services/http/user/book-http.service';
import { PublisherHttpService } from 'src/services/http/publisher-http.service';
import { AuthorHttpService } from 'src/services/http/user/author-http.service';
import { IButton } from 'src/app/shared/table-actions.component';
import { environment } from 'src/environments/environment';
import { BookReservationHttpService } from 'src/services/http/book-reservation.http.service';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-my-book-all-book',
  templateUrl: './my-book-all-book.component.html'
})
export class MyBookAllBookComponent extends TableComponent {

  publishers = [];
  authors = [];
  reservedBooks = [];

  @Searchable("Book.Title", "like") title;
  @Searchable("Barcode", "like") barcode;
  @Searchable("Book.PublisherId", "eq") publisher;
  @Searchable("Book.AuthorId", "eq") author;
  @Searchable("Status.Name", "like") status;
  issueDate;

  serverUrl = environment.serverUri;

  buttons: IButton[] = [

    {
      label: 'request',
      action: d => this.requestForReserve(d),
      icon: 'arrow-up'
    }
  ]

  constructor(
    private bookHttpService: BookHttpService,
    private bookReservationHttpService: BookReservationHttpService,
    private publisherHttpService: PublisherHttpService,
    private authorHttpService: AuthorHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(bookHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
    this.getReserveBooksByUser(this.user.id);
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/library/books/items/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/library/books/items/add');
    }
  }

  gets() {
    this.load();
    this.loading = true;
    const request = [
      this.authorHttpService.list(),
      this.publisherHttpService.list(),
    ]
    this.subscribe(forkJoin(request),
      (res: any) => {
        this.authors = res[0].data.items;
        this.publishers = res[1].data.items;
      },
      err => {
        this.loading = false;
      }
    );
  }

  refresh() {
    this.load();
  }

  search() {
    this.load();
  }

  isReserved(book) {

    return this.reservedBooks.some(el => el.title == book.title);
  }
  getReserveBooksByUser(userId) {

    let s = `Search=StatusId eq 2&Search=ReservedForId eq ${userId}&limit=1`

    this.subscribe(this.bookHttpService.listBookItems(null, s),
      (res: any) => {
        this.reservedBooks = res.data.items;
        console.log(this.reservedBooks);
      }
    );

  }

  load() {
    super.load((p, s) => {

      return this.bookHttpService.list(p, s);
    })
  }

  issue(item) {
    this.goTo(`/admin/library/books/items/${item.id}/issues`);
  }

  return(item) {
    this.goTo(`/admin/library/books/items/${item.id}/returns`);
  }

  requestForReserve(item) {
    console.log(item);
    this.loading = true;

    // get first available bookitem of selected book
    let s = `Search=Book.Id eq ${item.id}&Search=StatusId eq 1&limit=1`

    this.subscribe(this.bookHttpService.listBookItems(null, s),
      (res: any) => {
        if (res.data.items.length) {

          var body = {
            bookItem: res.data.items[0].id
          };
          //send reserve request
          this.subscribe(this.bookReservationHttpService.reserveBymember(body),
            (res: any) => {
              this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
            }
          );

        }
        else {
          this.failed(MESSAGE_KEY.NO_BOOK_ITEM_FOUND);
        }

        this.loading = false;

      },
      err => {
        this.loading = false;
      }
    );


  }



}
