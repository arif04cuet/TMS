import { Component, ViewChild } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';

import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { AssetMaintenanceHttpService } from 'src/services/http/asset/asset-maintenance-http.service';
import { AssetBaseHttpService } from 'src/services/http/asset/asset-http-service';

@Component({
  selector: 'app-asset-maintenance-add',
  templateUrl: './asset-maintenance-add.component.html'
})
export class AssetMaintenanceAddComponent extends FormComponent {

  loading: boolean = true;
  statuses = [];

  @ViewChild('supplierSelect') supplierSelect: SelectControlComponent;

  private assetId;

  constructor(
    private activatedRoute: ActivatedRoute,
    private assetMaintenanceHttpService: AssetMaintenanceHttpService,
    private assetHttpService: AssetBaseHttpService,
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
      minQuantity: [null, [], this.v.required.bind(this)]
    });
    super.ngOnInit(this.activatedRoute.snapshot);

  }

  ngAfterViewInit() {

    this.supplierSelect.register((pagination, search) => {
      return this.assetHttpService.suppliers(pagination, search);
    }).fetch();

  }

  submit(): void {
    const body = this.constructObject(this.form.controls);
    console.log(body);
    this.submitForm(
      {
        request: this.assetMaintenanceHttpService.add(this.id, body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.assetMaintenanceHttpService.edit(this.id, body),
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
      this.subscribe(this.assetMaintenanceHttpService.get(id),
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
    this.goTo('/admin/asset');
  }

}
