import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { forkJoin } from 'rxjs';
import { VendorHttpService } from 'src/services/http/vendor-http.service';
import { CommonHttpService } from 'src/services/http/common-http.service';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';


@Component({
  selector: 'app-vendor-list',
  templateUrl: './vendor-list.component.html',
  styleUrls: ['./vendor-list.component.scss']
})
export class VendorListComponent extends TableComponent {

  statuses = [];

  @Searchable("VendorName", "like") vendorName;
  @Searchable("VendorEmail", "like") vendorEmail;
  @Searchable("AccountManagerName", "like") accountManagerName;
  @Searchable("AccountManagerPhone", "like") accountManagerPhone;
  @Searchable("StatusId", "like") status;

  constructor(
    private vendorHttpService: VendorHttpService,
    private commonHttpService: CommonHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(vendorHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();

    this.onDeleted = (res: any) => {
      this.gets();
    }
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/asset/vendors/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/asset/vendors/add');
    }
  }

  gets(pagination = null, search = null) {
    this.loading = true;
    const request = [
      this.vendorHttpService.list(pagination, search),
      this.commonHttpService.getStatusList()
    ]
    this.subscribe(forkJoin(request),
      (res: any) => {
        this.fill(res[0]);
        this.statuses = res[1].data.items;
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
    this.vendorName = this.vendorEmail = this.accountManagerName = this.accountManagerPhone = this.status = '';
  }

}
