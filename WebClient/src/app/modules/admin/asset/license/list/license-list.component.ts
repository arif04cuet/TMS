import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { LicenseHttpService } from 'src/services/http/asset/license-http.service';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';


@Component({
  selector: 'app-license-list',
  templateUrl: './license-list.component.html'
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
    this.load();
    this.onDeleted = (res: any) => {
      this.load();
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

  view(model = null) {
    if (model) {
      this.goTo(`/admin/asset/licenses/${model.id}/view`);
    }
  }

  checkout(model = null) {
    if (model) {
      this.goTo(`/admin/asset/licenses/${model.id}/checkout`);
    }
  }

  search() {
    this.load();
  }

  refresh() {
    this.resetFilters();
    this.load();
  }

  resetFilters() {
    this.Name = this.ProductKey = this.IsActive = '';
  }

}
