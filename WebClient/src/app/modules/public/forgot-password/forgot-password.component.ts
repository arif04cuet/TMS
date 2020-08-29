import { Component } from '@angular/core';
import { AuthService } from 'src/services/auth.service';
import { FormComponent } from 'src/app/shared/form.component';
import { CommonValidator } from 'src/validators/common.validator';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html'
})
export class ForgotPasswordComponent extends FormComponent {

  constructor(
    private authService: AuthService,
    private v: CommonValidator,
    private activatedRoute: ActivatedRoute
  ) {
    super();
  }

  ngOnInit(): void {
    this.createForm({
      email: [null, [], this.v.required.bind(this)]
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  submit(): void {
    const body = this.constructObject(this.form.controls);
    this.submitForm(
      {
        request: this.authService.forgotPassword(body),
        succeed: res => {
          this.success('email.sent.please.follow.the.link');
        }
      },
      null
    );
  }

}
