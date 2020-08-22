import { Component, Input } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { LicenseHttpService } from 'src/services/http/asset/license-http.service';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';


@Component({
  selector: 'app-requisition-license-list',
  templateUrl: './license-list.component.html'
})
export class LicenseListComponent extends TableComponent {

  @Input() data: any;
  
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
    if (this.data && this.data.licenses) {
      this.setOfCheckedId = new Set<number>(this.data.licenses.map(x => x.id));
    }
    this.load();
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

  ngOnDestroy() {
    if (this.data) {
      this.data.licenses = Array.from(this.setOfCheckedId).map(x => {
        return this.items.find(y => y.id == x);
      });
    }
  }

}
