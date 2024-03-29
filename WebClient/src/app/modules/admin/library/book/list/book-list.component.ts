import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { forkJoin } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { BookHttpService } from 'src/services/http/user/book-http.service';
import { PublisherHttpService } from 'src/services/http/publisher-http.service';
import { AuthorHttpService } from 'src/services/http/user/author-http.service';
import { environment } from 'src/environments/environment';
import { IButton } from 'src/app/shared/table-actions.component';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html'
})
export class BookListComponent extends TableComponent {

  publishers = [];
  authors = [];
  serverUrl = environment.serverUri;
  buttons: IButton[] = [
    {
      label: 'edit',
      action: d => this.add(d),
      permissions: ['book.catalog.manage', 'book.catalog.update'],
      icon: 'edit'
    },
    {
      label: 'delete',
      action: d => this.delete(d),
      permissions: ['book.catalog.manage', 'book.catalog.delete'],
      icon: 'delete'
    }
  ]

  @Searchable("Title", "like") title;
  @Searchable("Isbn", "like") isbn;
  @Searchable("PublisherId", "eq") publisher;
  @Searchable("AuthorId", "eq") author;

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
      this.goTo(`/admin/library/books/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/library/books/add');
    }
  }

  gets(pagination = null, search = null) {
    this.loading = true;
    const request = [
      this.bookHttpService.list(pagination, search),
      this.authorHttpService.list(),
      this.publisherHttpService.list(),
    ]
    this.subscribe(forkJoin(request),
      (res: any) => {
        this.fill(res[0]);
        this.authors = res[1].data.items;
        this.publishers = res[2].data.items;
      },
      err => {
        console.log(err);
        this.loading = false;
      }
    );
  }

  refresh() {
    this.gets(null, this.getSearchTerms());
  }

  search() {
    this.gets(null, this.getSearchTerms())
  }

}
