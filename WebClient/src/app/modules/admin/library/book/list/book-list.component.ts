import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { forkJoin } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { UserHttpService } from 'src/services/http/user-http.service';
import { BookHttpService } from 'src/services/http/book-http.service';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html'
})
export class BookListComponent extends TableComponent {

  users = [];

  @Searchable("Name", "like") name;
  @Searchable("LibrarianId", "eq") librarian;

  constructor(
    private bookHttpService: BookHttpService,
    private userHttpService: UserHttpService,
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
      this.userHttpService.list()
    ]
    this.subscribe(forkJoin(request),
      (res: any) => {
        this.fill(res[0]);
        this.users = res[1].data.items;
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
