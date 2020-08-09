import { Component } from '@angular/core';
import { FormComponent } from 'src/shared/form.component';
import { Validators } from '@angular/forms';
import { RegistrationHttpService } from 'src/services/registration-http-service';
import { CommonValidator } from 'src/shared/common.validator';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent extends FormComponent {

  designations = [];

  constructor(private registrationHttpService: RegistrationHttpService,
    private v: CommonValidator) {
    super();
  }

  ngOnInit(): void {
    this.createForm({
      fullName: [null, [], this.v.required.bind(this)],
      email: [null, [], this.v.required.bind(this)],
      password: [null, [], this.v.required.bind(this)],
      mobile: [null, [], this.v.mobile.bind(this)],
      designation: [null, [], this.v.required.bind(this)]
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
          this.form.reset();
        },
        failed: err => {
          this.log(err);
        }
      },
      null
    );
  }

  getData() {
    this.subscribe(this.registrationHttpService.designations(),
      (res: any) => {
        this.designations = res.data.items
      }
    );
  }

}
