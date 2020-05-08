import { Component, ViewChild } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';
import { LicenseHttpService } from 'src/services/http/asset/license-http.service';

import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { UserHttpService } from 'src/services/http/user/user-http.service';

@Component({
  selector: 'app-license-checkout',
  templateUrl: './license-checkout.component.html'
})
export class LicenseCheckoutComponent extends FormComponent {

  loading: boolean = true;
  data: any = {};
  private checkoutId: number;
  
  @ViewChild('userSelect') userSelect: SelectControlComponent;

  constructor(
    private activatedRoute: ActivatedRoute,
    private licenseHttpService: LicenseHttpService,
    private userHttpService: UserHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit(): void {
    this.getData();
    this.onCheckMode = id => this.get(id);
    super.ngOnInit(this.activatedRoute.snapshot);
    this.checkoutId = this._activatedRouteSnapshot.queryParams.checkout;
    this.createForm({
      licenseSeatId: [this.checkoutId? +this.checkoutId : 0],
      issuedToUserId: [null, [], this.v.required.bind(this)],
      note: [null, [], this.v.required.bind(this)]
    });
    
  }

  ngAfterViewInit() {
    this.userSelect.register((pagination, search) => {
      return this.userHttpService.list(pagination, search);
    }).fetch();

  }

  submit(): void {
    const body = this.constructObject(this.form.controls);
    this.validateForm(() => {
      this.subscribe(this.licenseHttpService.checkout(this.id, body),
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

  getData() {

  }
  
  cancel() {
    this.goTo('/admin/asset/licenses');
  }

}
