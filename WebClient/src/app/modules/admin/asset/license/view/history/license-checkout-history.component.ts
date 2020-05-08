import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { LicenseHttpService } from 'src/services/http/asset/license-http.service';


@Component({
  selector: 'app-license-checkout-history',
  templateUrl: './license-checkout-history.component.html'
})
export class LicenseCheckoutHistoryComponent extends TableComponent {

  @Searchable("Name", "like") Name;

  private id;

  constructor(
    private licenseHttpService:LicenseHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(licenseHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.id = this._activatedRouteSnapshot.params.id;
    this.load();
  }

  search() {
    this.load();
  }

  refresh() {
    this.load();
  }

  load() {
    super.load((p, s) => {
      return this.licenseHttpService.listCheckoutHistory(this.id, p, s);
    })
  }

}
