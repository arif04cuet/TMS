import { Component } from '@angular/core';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { MethodHttpService } from 'src/services/http/course/method-http.service';
import { FormBaseComponent } from 'src/app/shared/form-base.component';

@Component({
  selector: 'app-method-add',
  templateUrl: './method-add.component.html'
})
export class MethodAddComponent extends FormBaseComponent {

  loading: boolean = true;

  constructor(
    private methodHttpService: MethodHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit(): void {
    this.createForm({
      name: [null, [], this.v.required.bind(this)]
    });
  }

  submit(): void {
    const body = this.constructObject(this.form.controls);
    this.submitForm(
      {
        request: this.methodHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.methodHttpService.edit(this.id, body),
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
      this.subscribe(this.methodHttpService.get(id),
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
    this.closeModal();
  }

}
