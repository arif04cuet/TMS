import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { forkJoin } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { AuthorHttpService } from 'src/services/http/user/author-http.service';
import { LibraryMemberHttpService } from 'src/services/http/library-member-http.service';
import { LibraryReportHttpService } from 'src/services/http/library-report-http.service';

@Component({
  selector: 'app-issue-list',
  templateUrl: './issue-list.component.html'
})
export class IssueListComponent extends TableComponent {

  members = [];
  authors = [];

  @Searchable("Book.Title", "like") title;
  @Searchable("MemberId", "eq") issuedTo;
  @Searchable("Book.AuthorId", "eq") author;

  constructor(
    private libraryReportHttpService: LibraryReportHttpService,
    private libraryMemberHttpService: LibraryMemberHttpService,
    private authorHttpService: AuthorHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(libraryReportHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
  }

  gets() {
    this.load();
    this.loading = true;
    const request = [
      this.authorHttpService.list(),
      this.libraryMemberHttpService.list(),
    ]
    this.subscribe(forkJoin(request),
      (res: any) => {
        this.authors = res[0].data.items;
        this.members = res[1].data.items;
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
      return this.libraryReportHttpService.issues(p, s);
    });
  }

}
