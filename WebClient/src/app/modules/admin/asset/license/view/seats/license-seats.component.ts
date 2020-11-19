import { Component } from '@angular/core';
import { BaseComponent } from 'src/app/shared/base.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';
import { LicenseHttpService } from 'src/services/http/asset/license-http.service';
import { UserHttpService } from 'src/services/http/user/user-http.service';

@Component({
  selector: 'app-license-seats',
  templateUrl: './license-seats.component.html'
})
export class LicenseSeatsComponent extends BaseComponent {

  loading: boolean = true;
  item;
  licenseId: number;

  constructor(
    private activatedRoute: ActivatedRoute,
    private licenseHttpService: LicenseHttpService,
    private userHttpService: UserHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit(): void {
    this._activatedRouteSnapshot = this.activatedRoute.snapshot

    const id = this.getQueryParams('id');

    this.get(id);

  }

  get(id) {

    this.loading = true;

    this.subscribe(this.licenseHttpService.getDetails(id),
      (res: any) => {
        this.item = res.data;
        this.licenseId = res.data.id;
        this.loading = false;
      }
    );


  }

  checkout(licenseSeatId) {
    this.goTo(`/admin/asset/licenses/${this.licenseId}/checkout?checkout=${licenseSeatId}`);
  }

  checkin(licenseSeatId) {
    this.goTo(`/admin/asset/licenses/${this.licenseId}/checkin?checkin=${licenseSeatId}`);
  }

  cancel() {
    this.goTo('/admin/asset/licenses');
  }

  seatName(value) {

    return this.splitTranslate(value);
  }

}
