import { Component } from '@angular/core';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { AuthorHttpService } from 'src/services/http/user/author-http.service';
import { FormBaseComponent } from 'src/app/shared/form-base.component';

@Component({
  selector: 'app-author-add',
  templateUrl: './author-add.component.html'
})
export class AuthorAddComponent extends FormBaseComponent {

  loading: boolean = true;

  constructor(
    private authorHttpService: AuthorHttpService,
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
        request: this.authorHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.authorHttpService.edit(this.id, body),
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
      this.subscribe(this.authorHttpService.get(id),
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
