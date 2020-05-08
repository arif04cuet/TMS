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
  statuses = [];
  name : string = '';
  productKey: string = '';

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
    this.createForm({
      issuedToUserId: [null, [], this.v.required.bind(this)],
      note: [null, [], this.v.required.bind(this)]
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  ngAfterViewInit() {
    this.userSelect.register((pagination, search) => {
      return this.userHttpService.list(pagination, search);
    }).fetch();

  }

  submit(): void {
    const body = this.constructObject(this.form.controls);
    console.log(body);
    this.submitForm(
      {
        request: this.licenseHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.licenseHttpService.checkout(this.id, body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_UPDATED);
        }
      }
    );
  }

  get(id) {
    this.loading = true;
    if (id != null) {
      this.subscribe(this.licenseHttpService.get(id),
        (res: any) => {
          debugger;
          this.name = res.data.name;
          this.productKey = res.data.productKey;
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
