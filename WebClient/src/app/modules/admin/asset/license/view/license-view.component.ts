import { Component, ViewChild } from '@angular/core';
import { BaseComponent } from 'src/app/shared/base.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';
import { LicenseHttpService } from 'src/services/http/asset/license-http.service';
import { UserHttpService } from 'src/services/http/user/user-http.service';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';

@Component({
  selector: 'app-license-view',
  templateUrl: './license-view.component.html'
})
export class LicenseViewComponent extends BaseComponent {

  loading: boolean = true;
  item;

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
    //console.log(id);
    this.get(id);

  }

  get(id) {

    this.loading = true;

    this.subscribe(this.licenseHttpService.getDetails(id),
      (res: any) => {

        this.item = res.data;
        console.log(this.item.seatList);
        this.loading = false;
      }
    );


  }

  cancel() {
    this.goTo('/admin/asset/licenses');
  }
  back_to_list() {

    this.goTo('/admin/asset/licenses');

  }
}
