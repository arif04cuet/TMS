import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { forkJoin } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { OfficeHttpService } from 'src/services/http/user/office-http.service';

@Component({
  selector: 'app-office-list',
  templateUrl: './office-list.component.html'
})
export class OfficeListComponent extends TableComponent {

  @Searchable("OfficeName", "like") name;

  constructor(
    private activatedRoute: ActivatedRoute,
    private officeHttpService: OfficeHttpService
  ) {
    super(officeHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/offices/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/offices/add');
    }
  }

  gets(pagination = null, search = null) {
    this.loading = true;
    const request = [
      this.officeHttpService.list(pagination, search)
    ]
    this.subscribe(forkJoin(request),
      (res: any) => {
        this.fill(res[0]);
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
