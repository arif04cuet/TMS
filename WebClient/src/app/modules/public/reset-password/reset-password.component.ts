import { Component } from '@angular/core';
import { AuthService } from 'src/services/auth.service';
import { FormComponent } from 'src/app/shared/form.component';
import { CommonValidator } from 'src/validators/common.validator';
import { ActivatedRoute } from '@angular/router';
import { FormControl } from '@angular/forms';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { of } from 'rxjs';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html'
})
export class ResetPasswordComponent extends FormComponent {

  constructor(
    private authService: AuthService,
    private v: CommonValidator,
    private activatedRoute: ActivatedRoute
  ) {
    super();
  }

  ngOnInit(): void {
    this.createForm({
      password: [null, [], this.v.required.bind(this)],
      confirmPassword: [null, [], this.confirmPasswordValidation.bind(this)],
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  submit(): void {
    const body: any = this.constructObject(this.form.controls);
    body.forgotPasswordToken = this._activatedRouteSnapshot.queryParams.token;
    this.submitForm(
      {
        request: this.authService.resetPassword(body),
        succeed: res => {
          this.success('success');
        }
      },
      null
    );
  }

  confirmPasswordValidation(control: FormControl) {
    if (!control.value) {
      return this.error(MESSAGE_KEY.THIS_FIELD_IS_REQUIRED);
    }
    const password = this.form.controls.password.value;
    if (password != control.value) {
      return this.error('password.not.matched');
    }
    return of(true);
  }

}
