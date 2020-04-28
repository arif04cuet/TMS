import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { forkJoin } from 'rxjs';
import { LicenseHttpService } from 'src/services/http/asset/license-http.service';
import { CommonHttpService } from 'src/services/http/common-http.service';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';


@Component({
  selector: 'app-license-list',
  templateUrl: './license-list.component.html',
  styleUrls: ['./license-list.component.scss']
})
export class LicenseListComponent extends TableComponent {

  statuses = [];

  @Searchable("Name", "like") Name;
  @Searchable("ProductKey", "like") ProductKey;
  @Searchable("IsActive", "eq") IsActive;


  constructor(
    private licenseHttpService: LicenseHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(licenseHttpService);
  }

  ngOnInit() {

    this.statuses = this.licenseHttpService.getStatus();

    this.snapshot(this.activatedRoute.snapshot);
    this.gets();

    this.onDeleted = (res: any) => {
      this.gets();
    }
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/asset/licenses/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/asset/licenses/add');
    }
  }

  gets(pagination = null, search = null) {
    this.loading = true;
    const request = [
      this.licenseHttpService.list(pagination, search)
    ]
    this.subscribe(forkJoin(request),
      (res: any) => {
        this.fill(res[0]);
      },
      err => {
        console.log(err);
        this.loading = false;
      }
    );

  }

  search() {
    this.gets(null, this.getSearchTerms())
  }

  refresh() {
    this.resetFilters();
    this.gets(null, null);
  }

  resetFilters() {
    this.Name = this.ProductKey = this.IsActive = '';
  }

}
