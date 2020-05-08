import { Component } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';

import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { LicenseHttpService } from 'src/services/http/asset/license-http.service';

@Component({
  selector: 'app-license-checkin',
  templateUrl: './license-checkin.component.html'
})
export class LicenseCheckinComponent extends FormComponent {

  loading: boolean = true;
  data: any = {}

  private checkinId: number;

  constructor(
    private activatedRoute: ActivatedRoute,
    private licenseHttpService: LicenseHttpService,
  ) {
    super();
  }

  ngOnInit(): void {
    this.onCheckMode = id => this.get(id);
    super.ngOnInit(this.activatedRoute.snapshot);
    this.checkinId = this._activatedRouteSnapshot.queryParams.checkin;
    this.createForm({
      licenseSeatId: [this.checkinId? +this.checkinId : 0],
      note: []
    });
  }

  submit(): void {
    const body = this.constructObject(this.form.controls);
    this.validateForm(() => {
      this.subscribe(this.licenseHttpService.checkin(this.checkinId, body),
        (res: any) => {
          this.cancel();
          this.success(MESSAGE_KEY.CHECKIN_SUCCESSFUL);
          this.loading = false;
        },
        err => {
          this.loading = false;
        });
    });
  }

  get(id) {
    this.loading = true;
    if (id != null) {
      this.subscribe(this.licenseHttpService.get(id),
        (res: any) => {
          this.data = res.data;
          this.loading = false;
        }
      );
    }
    else {
      this.loading = false;
    }
  }

  cancel() {
    this.goTo('/admin/asset/licenses');
  }

}
