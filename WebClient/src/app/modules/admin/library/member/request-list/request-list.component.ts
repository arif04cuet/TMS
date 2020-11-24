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

  libraries = [];
  @Searchable("FullName", "like") name;
  @Searchable("LibraryId", "eq") library;
  @Searchable("Mobile", "like") mobile;
  @Searchable("Email", "like") email;


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
    this.gets();
  }

  gets(pagination = null, search = null) {
    this.load((pagination, search) => {
      search += `&IsApproved=false`;
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

    const request = [
      this.libraryHttpService.list(pagination, search),
    ]
    this.subscribe(forkJoin(request),
      (res: any) => {

        this.libraries = res[0].data.items;

      },
      err => {
        console.log(err);
        this.loading = false;
      }
    );


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
