import { Component, ViewChild } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';

import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { ComponentHttpService } from 'src/services/http/asset/component-http.service';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { AssetBaseHttpService } from 'src/services/http/asset/asset-http-service';
import { FormControl } from '@angular/forms';
import { of } from 'rxjs';

@Component({
  selector: 'app-component-checkout',
  templateUrl: './component-checkout.component.html'
})
export class ComponentCheckoutComponent extends FormComponent {

  loading: boolean = true;
  data: any = {};

  @ViewChild('assetSelect') assetSelect: SelectControlComponent;

  constructor(
    private activatedRoute: ActivatedRoute,
    private componentHttpService: ComponentHttpService,
    private assetHttpService: AssetBaseHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit(): void {
    this.onCheckMode = id => this.get(id);
    this.createForm({
      componentId: [],
      assetId: [null, [], this.v.required.bind(this)],
      quantity: [null, [], this.quantityValidation.bind(this)],
      note: []
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  ngAfterViewInit() {
    this.assetSelect.register((pagination, search) => {
      return this.assetHttpService.list(pagination, search);
    }).fetch();
  }

  submit(): void {
    const body = this.constructObject(this.form.controls);
    this.validateForm(() => {
      this.subscribe(this.componentHttpService.checkout(this.id, body),
        (res: any) => {
          this.cancel();
          this.success(MESSAGE_KEY.CHECKOUT_SUCCESSFUL);
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
          this.setValue('componentId', res.data.id);
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
    else if (Number(control.value) > this.data.available) {
      return this.error('quantity.exceeds');
    }
    return of(false);
  }

}
