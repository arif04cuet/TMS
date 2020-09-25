import { Component } from '@angular/core';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { FacilitiesHttpService } from 'src/services/http/hostel/facilities-http.service';
import { FormBaseComponent } from 'src/app/shared/form-base.component';

@Component({
  selector: 'app-facilities-add',
  templateUrl: './facilities-add.component.html'
})
export class FacilitiesAddComponent extends FormBaseComponent {

  loading: boolean = true;

  constructor(
    private facilitiesHttpService: FacilitiesHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit(): void {
    this.createForm({
      name: [null, [], this.v.required.bind(this)],
    });
  }

  submit(): void {
    const body = this.constructObject(this.form.controls);
    this.submitForm(
      {
        request: this.facilitiesHttpService.add(body),
        succeed: res => {
          this.cancel(true);
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.facilitiesHttpService.edit(this.id, body),
        succeed: res => {
          this.cancel(true);
          this.success(MESSAGE_KEY.SUCCESSFULLY_UPDATED);
        }
      }
    );
  }

  get(id) {
    this.loading = true;
    if (id != null) {
      this.subscribe(this.facilitiesHttpService.get(id),
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
