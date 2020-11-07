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

@Component({
  selector: 'app-my-book-all-book',
  templateUrl: './my-book-all-book.component.html'
})
export class MyBookAllBookComponent extends TableComponent {

  publishers = [];
  authors = [];

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
      action: d => this.requestBook(d),
      icon: 'arrow-up'
    }
  ]

  constructor(
    private bookHttpService: BookHttpService,
    private publisherHttpService: PublisherHttpService,
    private authorHttpService: AuthorHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(bookHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
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

  load() {
    super.load((p, s) => {
      if (this.issueDate && this.issueDate.length) {
        if (this.issueDate[0]) {
          s += `&IssueDateStart=${this.issueDate[0].toISOString()}`
        }
        if (this.issueDate[1]) {
          s += `&IssueDateEnd=${this.issueDate[1].toISOString()}`
        }
      }
      return this.bookHttpService.list(p, s)
    })
  }

  issue(item) {
    this.goTo(`/admin/library/books/items/${item.id}/issues`);
  }

  return(item) {
    this.goTo(`/admin/library/books/items/${item.id}/returns`);
  }

  requestBook(item) {
    console.log(item);
  }



}
