import { Component } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';

import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { ComponentHttpService } from 'src/services/http/asset/component-http.service';

@Component({
  selector: 'app-component-checkin',
  templateUrl: './component-checkin.component.html'
})
export class ComponentCheckinComponent extends FormComponent {

  loading: boolean = true;
  data: any = {}

  private checkoutId;

  constructor(
    private activatedRoute: ActivatedRoute,
    private componentHttpService: ComponentHttpService,
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
      this.subscribe(this.componentHttpService.checkin(this.checkoutId, body),
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
      this.subscribe(this.componentHttpService.get(id),
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
    this.goTo('/admin/asset/components');
  }

}
