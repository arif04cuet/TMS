import { Component } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { forkJoin } from 'rxjs';
import { CommonValidator } from 'src/validators/common.validator';
import { SupplierHttpService } from 'src/services/http/asset/supplier-http.service';
import { CommonHttpService } from 'src/services/http/common-http.service';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';

@Component({
  selector: 'app-supplier-add',
  templateUrl: './supplier-add.component.html'
})
export class SupplierAddComponent extends FormComponent {

  loading: boolean = true;

  statuses = [];


  constructor(
    private activatedRoute: ActivatedRoute,
    private supplierHttpService: SupplierHttpService,
    private commonHttpService: CommonHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit(): void {
    this.getData();
    this.onCheckMode = id => this.get(id);
    this.createForm({
      name: [null, [], this.v.required.bind(this)],
      address: [null, [], this.v.required.bind(this)],
      contactName: [null, [], this.v.required.bind(this)],
      contactEmail: [null, [], this.v.email.bind(this)],
      contactPhone: [null, [], this.v.mobile.bind(this)],
      isActive: [null, []]
    });
    super.ngOnInit(this.activatedRoute.snapshot);

  }

  submit(): void {
    const body = this.constructObject(this.form.controls);
    console.log(body);
    this.submitForm(
      {
        request: this.supplierHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.supplierHttpService.edit(this.id, body),
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
      this.subscribe(this.supplierHttpService.get(id),
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
    this.goTo('/admin/asset/suppliers');
  }

}
