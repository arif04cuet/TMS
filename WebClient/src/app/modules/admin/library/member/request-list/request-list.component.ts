import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { forkJoin } from 'rxjs';
import { CommonHttpService } from 'src/services/http/common-http.service';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { LibraryMemberHttpService } from 'src/services/http/library-member-http.service';
import { LibraryHttpService } from 'src/services/http/library-http.service';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-request-list',
  templateUrl: './request-list.component.html'
})
export class MemberRequestListComponent extends TableComponent {

  @Searchable("User.FullName", "like") name;
  @Searchable("Library.Name", "like") library;
  @Searchable("User.Mobile", "like") mobile;
  @Searchable("User.Email", "like") email;

  rowItemDisabledFilterKey = 'isApproved';
  environment = environment;

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
    this.gets2();
  }

  gets2(pagination = null, search = null) {
    this.load((pagination, search) => {
      var list = this.libraryMemberHttpService.listRequests(pagination, search).pipe(
        map((x: any) => {
          x.data.items.forEach(o => {
            o.photoUrl = `${environment.serverUri}/${o.photo}`;
          });
          return x;
        })
      );
      return list;
    });
  }

  gets(pagination = null, search = null) {
    this.loading = true;

    var response = this.libraryMemberHttpService.listRequests(pagination, search).pipe(
      map((x: any) => {
        x.data.items.forEach(o => {
          o.photoUrl = `${environment.serverUri}/${o.photo}`;
        });
        return x;
      })
    );

    console.log(response);
    return response;

  }

  refresh() {
    this.gets(null, this.getSearchTerms());
    this.listOfCurrentPageItems.filter(x => x[this.rowItemDisabledFilterKey]).forEach(({ id }) => this.updateCheckedSet(id, false));
    this.refreshCheckedStatus();
  }

  search() {
    this.gets(null, this.getSearchTerms())
  }

  approve() {
    const body = { ids: Array.from(this.setOfCheckedId) };
    this.loading = true;
    this.subscribe(this.libraryMemberHttpService.approveRequests(body),
      res => {
        this.refresh();
      },
      err => {
        this.loading = false;
      }
    );
  }

}
