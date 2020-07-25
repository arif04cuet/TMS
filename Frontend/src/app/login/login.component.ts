import { Component, ViewChild } from '@angular/core';
import { Validators } from '@angular/forms';
import { FormComponent } from 'src/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from 'src/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent extends FormComponent {

  libraries = []

  private redirect;

  constructor(
    private authService: AuthService,
    private activatedRoute: ActivatedRoute) {
    super();

    const snapshot = activatedRoute.snapshot;
    this.redirect = snapshot.params.redirect;
  }

  ngOnInit(): void {
    this.createForm({
      email: [null, [Validators.email, Validators.required]],
      password: [null, [Validators.required]]
    });
    this.markModeAsAdd();
  }

  submit(): void {
    const body: any = this.constructObject(this.form.controls);
    this.submitForm(
      {
        request: this.authService.login(body),
        succeed: res => {
          this.success('Success');
          if(this.redirect) {
            this.goTo(this.redirect);
          }
        },
        failed: err => {
          this.log(err);
        }
      },
      null
    );
  }

}
