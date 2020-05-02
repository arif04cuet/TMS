import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { forkJoin } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { LibraryMemberHttpService } from 'src/services/http/library-member-http.service';
import { LibraryHttpService } from 'src/services/http/library-http.service';

@Component({
  selector: 'app-fine-list',
  templateUrl: './fine-list.component.html'
})
export class FineListComponent extends TableComponent {

  members = [];

  @Searchable("MemberId", "eq") member;

  constructor(
    private libraryMemberHttpService: LibraryMemberHttpService,
    private libraryHttpService: LibraryHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(libraryHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
  }

  gets(pagination = null, search = null) {
    this.loading = true;
    const request = [
      this.libraryHttpService.listFines(pagination, search),
      this.libraryMemberHttpService.list(),
    ]
    this.subscribe(forkJoin(request),
      (res: any) => {
        this.fill(res[0]);
        this.members = res[1].data.items;
      },
      err => {
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
