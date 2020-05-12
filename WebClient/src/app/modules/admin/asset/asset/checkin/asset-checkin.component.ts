import { Component, ViewChild } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';

import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { AssetBaseHttpService } from 'src/services/http/asset/asset-http-service';
import { CommonValidator } from 'src/validators/common.validator';
import { StatusHttpService } from 'src/services/http/asset/status-http.service';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';

@Component({
  selector: 'app-asset-checkin',
  templateUrl: './asset-checkin.component.html'
})
export class AssetCheckinComponent extends FormComponent {

  @ViewChild('statusSelect') statusSelect: SelectControlComponent;

  loading: boolean = true;
  data: any = {}

  private checkoutId;

  constructor(
    private activatedRoute: ActivatedRoute,
    private assetHttpService: AssetBaseHttpService,
    private statusHttpService: StatusHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit(): void {
    this.onCheckMode = id => this.get(id);
    this.createForm({
      status: [null, [], this.v.required.bind(this)],
      checkinDate: [null, [], this.v.required.bind(this)],
      note: []
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  submit(): void {
    const body = this.constructObject(this.form.controls);
    this.validateForm(() => {
      this.subscribe(this.assetHttpService.checkin(this.checkoutId, body),
        (res: any) => {
          this.cancel();
          this.success(MESSAGE_KEY.CHECKIN_SUCCESSFUL);
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
      this.subscribe(this.assetHttpService.get(id),
        (res: any) => {
          this.data = res.data;
          this.checkoutId = res.data.checkoutId;
          this.loading = false;
        }
      );
    }
    else {
      this.loading = false;
    }
  }

  ngAfterViewInit() {
    this.statusSelect.register((pagination, search) => {
      return this.statusHttpService.list(pagination, search);
    }).fetch();
  }

  cancel() {
    this.goTo('/admin/asset');
  }

}
