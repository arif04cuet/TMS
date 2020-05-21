import { Component, ViewChild } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';

import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { ConsumableHttpService } from 'src/services/http/asset/consumable-http.service';
import { UserHttpService } from 'src/services/http/user/user-http.service';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { ItemCodeHttpService } from 'src/services/http/asset/itemcode-http.service';
import { FormControl } from '@angular/forms';
import { of } from 'rxjs';

@Component({
  selector: 'app-consumable-checkout',
  templateUrl: './consumable-checkout.component.html'
})
export class ConsumableCheckoutComponent extends FormComponent {

  loading: boolean = true;
  data: any = {};

  @ViewChild('userSelect') userSelect: SelectControlComponent;

  private itemCodeId;

  constructor(
    private activatedRoute: ActivatedRoute,
    private consumableHttpService: ConsumableHttpService,
    private itemCodeHttpService: ItemCodeHttpService,
    private userHttpService: UserHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit(): void {
    this.createForm({
      userId: [null, [], this.v.required.bind(this)],
      note: [],
      quantity: [null, [], this.quantityValidation.bind(this)]
    });
    const snapshot = this.activatedRoute.snapshot;
    super.ngOnInit(snapshot);
    this.itemCodeId = snapshot.params.id;
    this.get(this.itemCodeId);
  }

  ngAfterViewInit() {
    this.userSelect.register((pagination, search) => {
      return this.userHttpService.list(pagination, search);
    }).fetch();
  }

  submit(): void {
    const body: any = this.constructObject(this.form.controls);
    this.validateForm(() => {
      this.subscribe(this.consumableHttpService.checkoutByItemCode(this.itemCodeId, body),
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
    this.subscribe(this.itemCodeHttpService.get(id),
      (res: any) => {
        this.data = res.data;
        this.data.item = `${this.data.code} - ${this.data.name}`
        this.loading = false;
      }
    );
  }

  cancel() {
    this.goTo(`/admin/asset/consumables`);
  }

  quantityValidation(control: FormControl) {
    if (!control.value || isNaN(control.value) || Number(control.value) > Number(this.data.available)) {
      return this.error('allowed.value.is.x0.x1', {x0: 1, x1: this.data.available});
    }
    return of(false);
  }

}
