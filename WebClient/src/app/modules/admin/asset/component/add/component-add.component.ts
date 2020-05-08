import { Component, ViewChild } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';

import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { ComponentHttpService } from 'src/services/http/asset/component-http.service';

@Component({
  selector: 'app-component-add',
  templateUrl: './component-add.component.html'
})
export class ComponentAddComponent extends FormComponent {

  loading: boolean = true;
  statuses = [];

  @ViewChild('categorySelect') categorySelect: SelectControlComponent;
  @ViewChild('manufacturerSelect') manufacturerSelect: SelectControlComponent;
  @ViewChild('supplierSelect') supplierSelect: SelectControlComponent;
  @ViewChild('locationSelect') locationSelect: SelectControlComponent;

  constructor(
    private activatedRoute: ActivatedRoute,
    private componentHttpService: ComponentHttpService,
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
      return this.componentHttpService.manufacturers(pagination, search);
    }).fetch();

    this.categorySelect.register((pagination, search) => {
      let s = search || ""
      s += `&Search=Type eq 2`;
      return this.componentHttpService.categories(pagination, s);
    }).fetch();

    this.supplierSelect.register((pagination, search) => {
      return this.componentHttpService.suppliers(pagination, search);
    }).fetch();

    this.locationSelect.register((pagination, search) => {
      return this.componentHttpService.locations(pagination, search);
    }).fetch();

  }

  submit(): void {
    const body = this.constructObject(this.form.controls);
    console.log(body);
    this.submitForm(
      {
        request: this.componentHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.componentHttpService.edit(this.id, body),
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
      this.subscribe(this.componentHttpService.get(id),
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
    this.goTo('/admin/asset/components');
  }

}
