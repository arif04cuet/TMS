import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from 'src/services/auth.service';
import { HttpService } from 'src/services/http/http.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  form: FormGroup;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private httpService: HttpService,
    private router: Router
  ) { }

  ngOnInit(): void {

    this.form = this.fb.group({
      email: [null, [Validators.required, Validators.email]],
      password: [null, [Validators.required]],
      remember: []
    });

  }

  submitForm(): void {
    for (const i in this.form.controls) {
      this.form.controls[i].markAsDirty();
      this.form.controls[i].updateValueAndValidity();
    }

    const body = {
      username: this.form.controls.email.value,
      password: this.form.controls.password.value
    }

    this.router.navigateByUrl('/admin');

    // this.httpService.post('authenticate/login', body).subscribe(
    //   (res: any) => {
    //     if (res.authenticated) {
    //       this.authService.signin(body.username, body.password)
    //     }
    //   },
    //   error => {
    //     console.log(error);
    //   });

  }


}
