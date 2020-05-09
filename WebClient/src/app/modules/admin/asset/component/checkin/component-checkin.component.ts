import { Component } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';

import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { ComponentHttpService } from 'src/services/http/asset/component-http.service';
import { FormControl } from '@angular/forms';
import { of, forkJoin } from 'rxjs';

@Component({
  selector: 'app-component-checkin',
  templateUrl: './component-checkin.component.html'
})
export class ComponentCheckinComponent extends FormComponent {

  loading: boolean = true;
  data: any = {};
  checkoutData: any = {};

  private checkoutId;

  constructor(
    private activatedRoute: ActivatedRoute,
    private componentHttpService: ComponentHttpService,
  ) {
    super();
  }

  ngOnInit(): void {
    const snapshot = this.activatedRoute.snapshot;
    this.checkoutId = snapshot.queryParams.checkout;
    this.onCheckMode = id => this.get(id);
    this.createForm({
      quantity: [null, [], this.quantityValidation.bind(this)],
      note: []
    });
    super.ngOnInit(this.activatedRoute.snapshot);
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
      const requests = [
        this.componentHttpService.get(id),
        this.componentHttpService.getCheckout(id, this.checkoutId)
      ]
      this.subscribe(forkJoin(requests),
        (res: any) => {
          this.data = res[0].data;
          this.checkoutData = res[1].data;
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

  quantityValidation(control: FormControl) {
    if (!control.value) {
      return this.error(MESSAGE_KEY.THIS_FIELD_IS_REQUIRED);
    }
    else if (isNaN(control.value)) {
      return this.error(MESSAGE_KEY.MUST_BE_NUMERIC);
    }
    else if (Number(control.value) <= 0) {
      return this.error(MESSAGE_KEY.MUST_BE_GREATER_THAN_ZERO);
    }
    else if (Number(control.value) > this.checkoutData.quantity) {
      return this.error('quantity.exceeds');
    }
    return of(false);
  }

}
