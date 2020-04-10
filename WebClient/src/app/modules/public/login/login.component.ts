import { Component } from '@angular/core';
import { AuthService } from 'src/services/auth.service';
import { FormComponent } from 'src/app/shared/form.component';
import { CommonValidator } from 'src/validators/common.validator';
import { ActivatedRoute } from '@angular/router';
import { MessageKey } from 'src/constants/message-key.constant';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent extends FormComponent {

  constructor(
    private authService: AuthService,
    private v: CommonValidator,
    private activatedRoute: ActivatedRoute
  ) {
    super();
  }

  ngOnInit(): void {
    this.onCheckMode = id => this.get(id);
    this.createForm({
      email: [null, [], this.v.required.bind(this)],
      password: [null, [], this.v.required.bind(this)],
      // remember: []
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  submit(): void {
    const body = this.constructObject(this.form.controls);
    this.submitForm(
      {
        request: this.authService.login(body),
        succeed: res => {
          this.success(MessageKey.SUCCESSFULLY_LOGGED_IN);
          this.goTo('/admin');
        }
      },
      null
    );
  }

  get(id) {

  }

}
