import { Component } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { forkJoin } from 'rxjs';
import { CommonValidator } from 'src/validators/common.validator';
import { VendorHttpService } from 'src/services/http/vendor-http.service';
import { CommonHttpService } from 'src/services/http/common-http.service';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';

@Component({
  selector: 'app-vendor-add',
  templateUrl: './vendor-add.component.html'
})
export class VendorAddComponent extends FormComponent {

  loading: boolean = true;
  statuses = [];

  constructor(
    private activatedRoute: ActivatedRoute,
    private vendorHttpService: VendorHttpService,
    private commonHttpService: CommonHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit(): void {
    this.getData();
    this.onCheckMode = id => this.get(id);
    this.createForm({
      vendorName: [null, [], this.v.required.bind(this)],
      vendorEmail: [null, [], this.v.required.bind(this)],
      accountManagerName: [null, [], this.v.required.bind(this)],
      accountManagerPhone: [null, [], this.v.required.bind(this)],
      status: [null, [], this.v.required.bind(this)]
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  submit(): void {
    const body = this.constructObject(this.form.controls);
    console.log(body);
    this.submitForm(
      {
        request: this.vendorHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.vendorHttpService.edit(this.id, body),
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
      this.subscribe(this.vendorHttpService.get(id),
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

  getData() {
    const requests = [
      this.commonHttpService.getStatusList()
    ]
    this.subscribe(forkJoin(requests),
      (res: any[]) => {
        this.statuses = res[0].data.items
      }
    );
  }

  cancel() {
    this.goTo('/admin/asset/vendors');
  }

}
