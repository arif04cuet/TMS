import { Component, ViewChild } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';

import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { ConsumableHttpService } from 'src/services/http/asset/consumable-http.service';

@Component({
  selector: 'app-consumable-add',
  templateUrl: './consumable-add.component.html'
})
export class ConsumableAddComponent extends FormComponent {

  loading: boolean = true;
  statuses = [];

  @ViewChild('categorySelect') categorySelect: SelectControlComponent;
  @ViewChild('manufacturerSelect') manufacturerSelect: SelectControlComponent;
  @ViewChild('supplierSelect') supplierSelect: SelectControlComponent;
  @ViewChild('locationSelect') locationSelect: SelectControlComponent;

  constructor(
    private activatedRoute: ActivatedRoute,
    private consumableHttpService: ConsumableHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit(): void {
    this.onCheckMode = id => this.get(id);
    this.createForm({
      name: [null, [], this.v.required.bind(this)],
      category: [null, [], this.v.required.bind(this)],
      manufacturer: [],
      supplier: [],
      location: [],
      modelNo: [],
      orderNumber: [],
      purchaseDate: [],
      purchaseCost: [],
      note: [],
      quantity: [null, [], this.v.required.bind(this)],
      minQuantity: []
    });
    super.ngOnInit(this.activatedRoute.snapshot);

  }

  ngAfterViewInit() {

    this.manufacturerSelect.register((pagination, search) => {
      return this.consumableHttpService.manufacturers(pagination, search);
    }).fetch();

    this.categorySelect.register((pagination, search) => {
      let s = search || ""
      s += `&Search=Type eq 2`;
      return this.consumableHttpService.categories(pagination, s);
    }).fetch();

    this.supplierSelect.register((pagination, search) => {
      return this.consumableHttpService.suppliers(pagination, search);
    }).fetch();

    this.locationSelect.register((pagination, search) => {
      return this.consumableHttpService.locations(pagination, search);
    }).fetch();

  }

  submit(): void {
    const body = this.constructObject(this.form.controls);
    console.log(body);
    this.submitForm(
      {
        request: this.consumableHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.consumableHttpService.edit(this.id, body),
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
      this.subscribe(this.consumableHttpService.get(id),
        (res: any) => {
          this.setValues(this.form.controls, res.data);
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

}
