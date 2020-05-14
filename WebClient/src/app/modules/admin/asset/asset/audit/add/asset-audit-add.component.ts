import { Component } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';

import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { AssetBaseHttpService } from 'src/services/http/asset/asset-http-service';
import { AssetAuditHttpService } from 'src/services/http/asset/asset-audit-http.service';

@Component({
  selector: 'app-asset-audit-add',
  templateUrl: './asset-audit-add.component.html',
  providers: [AssetAuditHttpService, CommonValidator]
})
export class AssetAuditAddComponent extends FormComponent {

  loading: boolean = true;
  dataSet = [];

  constructor(
    private activatedRoute: ActivatedRoute,
    private assetAuditHttpService: AssetAuditHttpService,
    private assetHttpService: AssetBaseHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit(): void {
    this.onCheckMode = id => this.get(id);
    this.createForm({
      assetTag: [null, [], this.v.required.bind(this)],
      nextAuditDate: [null, [], this.v.required.bind(this)],
      note: []
    });
    const snapshot = this.activatedRoute.snapshot;
    super.ngOnInit(snapshot);
  }

  submit(): void {
    const body = this.constructObject(this.form.controls);
    this.submitForm(
      {
        request: this.assetAuditHttpService.add(body),
        succeed: res => {
          // this.cancel();
          this.audited();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.assetAuditHttpService.edit(this.id, body),
        succeed: res => {
          // this.cancel();
          this.audited();
          this.success(MESSAGE_KEY.SUCCESSFULLY_UPDATED);
        }
      }
    );
  }

  get(id) {
    this.loading = true;
    if (id != null) {
      this.subscribe(this.assetAuditHttpService.get(id),
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

  async audited() {
    const audit = {
      tag: this.form.controls.assetTag.value,
      status: await this.t('asset.audit.successfully.logged')
    }
    this.dataSet = [...this.dataSet, audit];

    this.form.controls.assetTag.setValue(null);
    this.form.controls.nextAuditDate.setValue(null);
    this.form.controls.note.setValue(null);
  }

  cancel() {
    this.goTo('/admin/asset/audit');
  }

}
