import { Component, ViewChild } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';

import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { UserHttpService } from 'src/services/http/user/user-http.service';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { AssetBaseHttpService } from 'src/services/http/asset/asset-http-service';
import { FormControl } from '@angular/forms';
import { of } from 'rxjs';
import { OfficeHttpService } from 'src/services/http/user/office-http.service';

@Component({
  selector: 'app-asset-checkout',
  templateUrl: './asset-checkout.component.html'
})
export class AssetCheckoutComponent extends FormComponent {

  loading: boolean = true;
  data: any = {};
  checkoutTo = 'user';

  @ViewChild('userSelect') userSelect: SelectControlComponent;
  @ViewChild('locationSelect') locationSelect: SelectControlComponent;
  @ViewChild('assetSelect') assetSelect: SelectControlComponent;

  constructor(
    private activatedRoute: ActivatedRoute,
    private assetHttpService: AssetBaseHttpService,
    private userHttpService: UserHttpService,
    private officeHttpService: OfficeHttpService,
  ) {
    super();
  }

  ngOnInit(): void {
    this.onCheckMode = id => this.get(id);
    this.createForm({
      assetId: [],
      chekoutToUserId: [null, [], this.checkoutToUserValidation.bind(this)],
      chekoutToLocationId: [null, [], this.checkoutToLocationValidation.bind(this)],
      chekoutToAssetId: [null, [], this.checkoutToAssetValidation.bind(this)],
      checkoutDate: [],
      expectedChekinDate: [],
      note: [],
      checkoutTo: [this.checkoutTo]
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  ngAfterViewInit() {
    this.userSelect.register((pagination, search) => {
      return this.userHttpService.list(pagination, search);
    }).fetch();

    this.locationSelect.register((pagination, search) => {
      return this.officeHttpService.list(pagination, search);
    }).fetch();

    this.assetSelect.register((pagination, search) => {
      return this.assetHttpService.list(pagination, search);
    }).fetch();
  }

  submit(): void {
    const body = this.constructObject(this.form.controls);
    this.validateForm(() => {
      this.subscribe(this.assetHttpService.checkout(this.id, body),
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
      this.subscribe(this.assetHttpService.get(id),
        (res: any) => {
          this.data = res.data;
          this.setValue('accessoryId', res.data.id);
          this.loading = false;
        }
      );
    }
    else {
      this.loading = false;
    }
  }

  cancel() {
    this.goTo('/admin/asset');
  }

  checkoutToUserValidation(control: FormControl) {
    if (this.checkoutTo == 'user' && !control.value) {
      return this.error(MESSAGE_KEY.THIS_FIELD_IS_REQUIRED);
    }
    return of(false);
  }

  checkoutToLocationValidation(control: FormControl) {
    if (this.checkoutTo == 'location' && !control.value) {
      return this.error(MESSAGE_KEY.THIS_FIELD_IS_REQUIRED);
    }
    return of(false);
  }

  checkoutToAssetValidation(control: FormControl) {
    if (this.checkoutTo == 'asset' && !control.value) {
      return this.error(MESSAGE_KEY.THIS_FIELD_IS_REQUIRED);
    }
    return of(false);
  }

  optionChange(e) {
    this.checkoutTo = e;
  }

}
