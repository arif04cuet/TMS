import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { forkJoin } from 'rxjs';
import { CommonHttpService } from 'src/services/http/common-http.service';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { LibraryMemberHttpService } from 'src/services/http/library-member-http.service';
import { LibraryHttpService } from 'src/services/http/library-http.service';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html'
})
export class MemberListComponent extends TableComponent {

  libraries = [];

  @Searchable("User.FullName", "like") name;
  @Searchable("LibraryId", "eq") library;
  @Searchable("User.Mobile", "like") mobile;
  @Searchable("User.Email", "like") email;

  constructor(
    private libraryMemberHttpService: LibraryMemberHttpService,
    private libraryHttpService: LibraryHttpService,
    private commonHttpService: CommonHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(libraryMemberHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/library/members/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/library/members/add');
    }
  }

  addFromExisting() {
    this.goTo('/admin/library/members/existing/add');
  }

  gets(pagination = null, search = null) {
    this.loading = true;
    const request = [
      this.libraryMemberHttpService.list(pagination, search),
      this.libraryHttpService.list(),
      this.commonHttpService.getStatusList()
    ]
    this.subscribe(forkJoin(request),
      (res: any) => {
        this.fill(res[0]);
        this.libraries = res[1].data.items;
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
