import { Component } from '@angular/core';
import { FormComponent } from 'src/shared/form.component';
import { Validators } from '@angular/forms';
import { RegistrationHttpService } from 'src/services/registration-http-service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent extends FormComponent {

  constructor(
    private registrationHttpService: RegistrationHttpService) {
    super();
  }

  ngOnInit(): void {
    this.createForm({
      fullName: [null, [Validators.required]],
      email: [null, [Validators.email, Validators.required]],
      password: [null, [Validators.required]],
      mobile: [null, [Validators.required]]
    });
    this.markModeAsAdd();
    this.getData();
  }

  submit(): void {
    const body: any = this.constructObject(this.form.controls);
    this.submitForm(
      {
        request: this.registrationHttpService.registration(body),
        succeed: res => {
          this.success('Success');
        },
        failed: err => {
          this.log(err);
        }
      },
      null
    );
  }

  getData() {
    // this.subscribe(this.registrationHttpService.list(null, null),
    //   (res: any) => {
    //     this.libraries = res.data.items
    //   }
    // );
  }

}
