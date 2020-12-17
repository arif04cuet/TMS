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
  selector: 'app-book-item-list',
  templateUrl: './book-item-list.component.html'
})
export class BookItemListComponent extends TableComponent {

  publishers = [];
  authors = [];
  statuses = [];

  @Searchable("Book.Title", "like") title;
  @Searchable("Barcode", "like") barcode;
  @Searchable("Book.PublisherId", "eq") publisher;
  @Searchable("Book.AuthorId", "eq") author;
  @Searchable("Status.Id", "eq") status;
  issueDate;

  buttons: IButton[] = [
    {
      label: 'issue',
      action: d => this.issue(d),
      condition: d => !d.issuedTo && d.status.id == 1,
      permissions: ['book.manage', 'book.issue'],
      type: 'primary'
    },
    {
      label: 'return',
      action: d => this.return(d),
      condition: d => d.status && d.status.id == 3, // Loaned
      permissions: ['book.manage', 'book.return'],
      type: 'primary'
    },
    {
      label: 'edit',
      action: d => this.add(d),
      permissions: ['book.manage', 'book.update'],
      icon: 'edit'
    },
    {
      label: 'delete',
      action: d => this.delete(d),
      permissions: ['book.manage', 'book.delete'],
      icon: 'delete'
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
    this.deleteFunc = id => this.bookHttpService.deleteBookItem(id);
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
      this.bookHttpService.listBookStatus()
    ]
    this.subscribe(forkJoin(request),
      (res: any) => {
        this.authors = res[0].data.items;
        this.publishers = res[1].data.items;
        this.statuses = res[2].data.items;
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
      return this.bookHttpService.listBookItems(p, s)
    })
  }

  issue(item) {
    this.goTo(`/admin/library/books/items/${item.id}/issues`);
  }

  return(item) {
    this.goTo(`/admin/library/books/items/${item.id}/returns`);
  }

}
