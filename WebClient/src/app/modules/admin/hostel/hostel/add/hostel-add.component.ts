import { Component } from '@angular/core';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { HostelHttpService } from 'src/services/http/hostel/hostel-http.service';
import { FormBaseComponent } from 'src/app/shared/form-base.component';

@Component({
  selector: 'app-hostel-add',
  templateUrl: './hostel-add.component.html'
})
export class HostelAddComponent extends FormBaseComponent {

  loading: boolean = true;

  constructor(
    private hostelHttpService: HostelHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit(): void {
    this.createForm({
      name: [null, [], this.v.required.bind(this)],
      address: []
    });
  }

  submit(): void {
    const body = this.constructObject(this.form.controls);
    this.submitForm(
      {
        request: this.hostelHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.hostelHttpService.edit(this.id, body),
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
      this.subscribe(this.hostelHttpService.get(id),
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

  cancel(result = {}) {
    this.closeModal(result);
  }

}
