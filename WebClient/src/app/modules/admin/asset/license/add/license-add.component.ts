import { Component, ViewChild } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';
import { LicenseHttpService } from 'src/services/http/asset/license-http.service';

import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { CategoryHttpService } from 'src/services/http/asset/category-http.service';

@Component({
  selector: 'app-license-add',
  templateUrl: './license-add.component.html'
})
export class LicenseAddComponent extends FormComponent {

  loading: boolean = true;
  statuses = [];

  @ViewChild('categorySelect') categorySelect: SelectControlComponent;
  @ViewChild('manufacturerSelect') manufacturerSelect: SelectControlComponent;
  @ViewChild('supplierSelect') supplierSelect: SelectControlComponent;
  @ViewChild('depreciationSelect') depreciationSelect: SelectControlComponent;
  @ViewChild('locationSelect') locationSelect: SelectControlComponent;

  constructor(
    private activatedRoute: ActivatedRoute,
    private licenseHttpService: LicenseHttpService,
    private categoryHttpService: CategoryHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit(): void {
    this.getData();
    this.onCheckMode = id => this.get(id);
    this.createForm({
      name: [null, [], this.v.required.bind(this)],
      categoryId: [null, [], this.v.required.bind(this)],
      manufacturerId: [null, []],
      supplierId: [null, [], this.v.required.bind(this)],
      depreciationId: [null, [], this.v.required.bind(this)],
      locationId: [null, [], this.v.required.bind(this)],
      productKey: [null, [], this.v.required.bind(this)],
      orderNumber: [null, []],
      licenseToName: [null, [], this.v.required.bind(this)],
      licenseToEmail: [null, [], this.v.required.bind(this)],
      purchaseDate: [null, [], this.v.required.bind(this)],
      purchaseCost: [null, [], this.v.required.bind(this)],
      expireDate: [null, [], this.v.required.bind(this)],
      note: [null, []],
      seats: [null, [], this.v.required.bind(this)],
      isActive: [null, []]
    });
    super.ngOnInit(this.activatedRoute.snapshot);

  }

  ngAfterViewInit() {

    this.manufacturerSelect.register((pagination, search) => {
      return this.licenseHttpService.manufacturers(pagination, search);
    }).fetch();

    this.categorySelect.register((pagination, search) => {
      return this.categoryHttpService.listByParent(3, pagination, search);
    }).fetch();

    this.supplierSelect.register((pagination, search) => {
      return this.licenseHttpService.suppliers(pagination, search);
    }).fetch();

    this.depreciationSelect.register((pagination, search) => {
      return this.licenseHttpService.depreciations(pagination, search);
    }).fetch();

    this.locationSelect.register((pagination, search) => {
      return this.licenseHttpService.locations(pagination, search);
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
        request: this.licenseHttpService.edit(this.id, body),
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
          this.setValues(this.form.controls, res.data);
          this.loading = false;
        }
      );
    }
    else {
      this.form.controls.isActive.setValue(true);
      this.loading = false;

    }
  }

  getData() {

  }

  cancel() {
    this.goTo('/admin/asset/licenses');
  }

}
