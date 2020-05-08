import { Component, ViewChild } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';

import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { AccessoryHttpService } from 'src/services/http/asset/accessory-http.service';
import { UserHttpService } from 'src/services/http/user/user-http.service';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';

@Component({
  selector: 'app-accessory-checkout',
  templateUrl: './accessory-checkout.component.html'
})
export class AccessoryCheckoutComponent extends FormComponent {

  loading: boolean = true;
  data: any = {};

  @ViewChild('userSelect') userSelect: SelectControlComponent;

  constructor(
    private activatedRoute: ActivatedRoute,
    private accessoryHttpService: AccessoryHttpService,
    private userHttpService: UserHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit(): void {
    this.onCheckMode = id => this.get(id);
    this.createForm({
      accessoryId: [],
      userId: [null, [], this.v.required.bind(this)],
      note: []
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
    this.validateForm(() => {
      this.subscribe(this.accessoryHttpService.checkout(this.id, body),
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
      this.subscribe(this.accessoryHttpService.get(id),
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
    this.goTo('/admin/asset/accessories');
  }

}
