import { Component } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';

import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { ConsumableHttpService } from 'src/services/http/asset/consumable-http.service';
import { of } from 'rxjs';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-consumable-checkin',
  templateUrl: './consumable-checkin.component.html'
})
export class ConsumableCheckinComponent extends FormComponent {

  loading: boolean = true;
  data: any = {}

  constructor(
    private activatedRoute: ActivatedRoute,
    private consumableHttpService: ConsumableHttpService,
  ) {
    super();
  }

  ngOnInit(): void {
    this.onCheckMode = id => this.get(id);
    this.createForm({
      note: [],
      quantity: [null, [], this.quantityValidation.bind(this)]
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  submit(): void {
    const body = this.constructObject(this.form.controls);
    this.validateForm(() => {
      this.subscribe(this.consumableHttpService.checkin(this.id, body),
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
      this.subscribe(this.consumableHttpService.getCheckout(id),
        (res: any) => {
          this.data = res.data;
          this.data.title = `${res.data.item.code} - ${res.data.item.name} - ${res.data.category.name}`
          this.loading = false;
        }
      );
    }
    else {
      this.loading = false;
    }
  }

  cancel() {
    this.goTo('/admin/asset/consumables');
  }

  quantityValidation(control: FormControl) {
    if (!control.value || isNaN(control.value) || Number(control.value) > Number(this.data.quantity)) {
      return this.error('allowed.value.is.x0.x1', {x0: 1, x1: this.data.quantity});
    }
    return of(false);
  }

}
