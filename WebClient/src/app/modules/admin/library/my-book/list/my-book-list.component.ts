import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { forkJoin } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { BookHttpService } from 'src/services/http/user/book-http.service';
import { PublisherHttpService } from 'src/services/http/publisher-http.service';
import { AuthorHttpService } from 'src/services/http/user/author-http.service';
import { IButton } from 'src/app/shared/table-actions.component';

@Component({
  selector: 'app-my-book-list',
  templateUrl: './my-book-list.component.html'
})
export class MyBookListComponent extends TableComponent {

  publishers = [];
  authors = [];

  @Searchable("Book.Title", "like") title;
  @Searchable("Barcode", "like") barcode;
  @Searchable("Book.PublisherId", "eq") publisher;
  @Searchable("Book.AuthorId", "eq") author;
  @Searchable("Status.Name", "like") status;
  issueDate;

  buttons: IButton[] = [

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
      return this.bookHttpService.listMyBookItems(p, s)
    })
  }

  issue(item) {
    this.goTo(`/admin/library/books/items/${item.id}/issues`);
  }

  return(item) {
    this.goTo(`/admin/library/books/items/${item.id}/returns`);
  }

}
