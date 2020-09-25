import { Component } from '@angular/core';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { SubjectHttpService } from 'src/services/http/subject-http.service';
import { FormBaseComponent } from 'src/app/shared/form-base.component';

@Component({
  selector: 'app-subject-add',
  templateUrl: './subject-add.component.html'
})
export class SubjectAddComponent extends FormBaseComponent {

  loading: boolean = true;

  constructor(
    private subjectHttpService: SubjectHttpService,
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
        request: this.subjectHttpService.add(body),
        succeed: res => {
          this.cancel(true);
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.subjectHttpService.edit(this.id, body),
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
      this.subscribe(this.subjectHttpService.get(id),
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
