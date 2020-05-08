import { Component } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';

import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { AccessoryHttpService } from 'src/services/http/asset/accessory-http.service';

@Component({
  selector: 'app-accessory-checkin',
  templateUrl: './accessory-checkin.component.html'
})
export class AccessoryCheckinComponent extends FormComponent {

  loading: boolean = true;
  data: any = {}

  private checkoutId;

  constructor(
    private activatedRoute: ActivatedRoute,
    private accessoryHttpService: AccessoryHttpService,
  ) {
    super();
  }

  ngOnInit(): void {
    this.onCheckMode = id => this.get(id);
    this.createForm({
      note: []
    });
    super.ngOnInit(this.activatedRoute.snapshot);
    this.checkoutId = this._activatedRouteSnapshot.queryParams.checkout;
  }

  submit(): void {
    const body = this.constructObject(this.form.controls);
    this.validateForm(() => {
      this.subscribe(this.accessoryHttpService.checkin(this.checkoutId, body),
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
      this.subscribe(this.accessoryHttpService.get(id),
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
    this.goTo('/admin/asset/accessories');
  }

}
