import { Component } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { FormControl } from '@angular/forms';
import { of, forkJoin } from 'rxjs';
import { CommonValidator } from 'src/validators/common.validator';
import { MessageKey } from 'src/constants/message-key.constant';
import { DesignationHttpService } from 'src/services/http/designation-http.service';

@Component({
  selector: 'app-designation-add',
  templateUrl: './designation-add.component.html'
})
export class DesignationAddComponent extends FormComponent {

  loading: boolean = true;

  constructor(
    private activatedRoute: ActivatedRoute,
    private designationHttpService: DesignationHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit(): void {
    this.onCheckMode = id => this.get(id);
    this.createForm({
      name: [null, [], this.v.required.bind(this)]
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  submit(): void {
    const body = this.constructObject(this.form.controls);
    this.submitForm(
      {
        request: this.designationHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MessageKey.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.designationHttpService.edit(this.id, body),
        succeed: res => {
          this.cancel();
          this.success(MessageKey.SUCCESSFULLY_UPDATED);
        }
      }
    );
  }

  get(id) {
    this.loading = true;
    if (id != null) {
      this.subscribe(this.designationHttpService.get(id),
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
    this.goTo('/admin/designations');
  }

}
