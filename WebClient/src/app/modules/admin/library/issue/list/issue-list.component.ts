import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { forkJoin } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { BookHttpService } from 'src/services/http/book-http.service';
import { AuthorHttpService } from 'src/services/http/author-http.service';
import { LibraryMemberHttpService } from 'src/services/http/library-member-http.service';

@Component({
  selector: 'app-issue-list',
  templateUrl: './issue-list.component.html'
})
export class IssueListComponent extends TableComponent {

  members = [];
  authors = [];

  @Searchable("Book.Title", "like") title;
  @Searchable("Book.MemberId", "eq") issuedTo;
  @Searchable("Book.AuthorId", "eq") author;

  constructor(
    private bookHttpService: BookHttpService,
    private libraryMemberHttpService: LibraryMemberHttpService,
    private authorHttpService: AuthorHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(bookHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
  }

  gets(pagination = null, search = null) {
    this.loading = true;
    const request = [
      this.bookHttpService.listIssues(pagination, search),
      this.authorHttpService.list(),
      this.libraryMemberHttpService.list(),
    ]
    this.subscribe(forkJoin(request),
      (res: any) => {
        this.fill(res[0]);
        this.authors = res[1].data.items;
        this.members = res[2].data.items;
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
