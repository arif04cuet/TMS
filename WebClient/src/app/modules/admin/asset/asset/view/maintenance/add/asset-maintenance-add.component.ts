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

  @ViewChild('typeSelect') typeSelect: SelectControlComponent;
  @ViewChild('assetSelect') assetSelect: SelectControlComponent;
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
      asset: [null, [], this.v.required.bind(this)],
      supplier: [null, [], this.v.required.bind(this)],
      type: [null, [], this.v.required.bind(this)],
      title: [null, [], this.v.required.bind(this)],
      startDate: [null, [], this.v.required.bind(this)],
      completionDate: [],
      cost: [],
      note: [],
      warrantyImprovement: []
    });
    const snapshot = this.activatedRoute.snapshot;
    super.ngOnInit(snapshot);
    this.assetId = snapshot.queryParams.assetId;
  }

  ngAfterViewInit() {

    this.supplierSelect.register((pagination, search) => {
      return this.assetHttpService.suppliers(pagination, search);
    }).fetch();

    this.assetSelect.register((pagination, search) => {
      return this.assetHttpService.list(pagination, search);
    })
      .onLoadCompleted(() => {
        if (this.assetId) {
          this.assetSelect.setValue(Number(this.assetId));
        }
      })
      .fetch();

    this.typeSelect.register((pagination, search) => {
      return this.assetMaintenanceHttpService.types();
    }).fetch();

  }

  submit(): void {
    const body = this.constructObject(this.form.controls);
    this.submitForm(
      {
        request: this.assetMaintenanceHttpService.add(body),
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
    this.goTo('/admin/asset/maintenances');
  }

}