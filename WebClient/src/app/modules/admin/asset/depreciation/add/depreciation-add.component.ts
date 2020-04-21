import { Component } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { forkJoin } from 'rxjs';
import { CommonValidator } from 'src/validators/common.validator';
import { DepreciationHttpService } from 'src/services/http/asset/depreciation-http.service';
import { CommonHttpService } from 'src/services/http/common-http.service';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';

@Component({
  selector: 'app-depreciation-add',
  templateUrl: './depreciation-add.component.html'
})
export class DepreciationAddComponent extends FormComponent {

  loading: boolean = true;

  statuses = [];


  constructor(
    private activatedRoute: ActivatedRoute,
    private depreciationHttpService: DepreciationHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit(): void {
    this.getData();
    this.onCheckMode = id => this.get(id);
    this.createForm({
      name: [null, [], this.v.required.bind(this)],
      term: [null, [], this.v.required.bind(this)],
      isActive: [null, []]
    });
    super.ngOnInit(this.activatedRoute.snapshot);

  }

  submit(): void {
    const body = this.constructObject(this.form.controls);
    console.log(body);
    this.submitForm(
      {
        request: this.depreciationHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.depreciationHttpService.edit(this.id, body),
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
      this.subscribe(this.depreciationHttpService.get(id),
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
    this.goTo('/admin/asset/depreciations');
  }

}
