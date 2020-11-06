import { Component } from '@angular/core';
import { FormComponent } from 'src/shared/form.component';
import { Validators } from '@angular/forms';
import { RegistrationHttpService } from 'src/services/registration-http-service';
import { CommonValidator } from 'src/shared/common.validator';
import { MediaHttpService } from 'src/services/media-http.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent extends FormComponent {

  designations = [];
  photoUrl;
  photoLoading = false;

  constructor(
    private registrationHttpService: RegistrationHttpService,
    private v: CommonValidator,
    private mediaHttpService: MediaHttpService
  ) {
    super();
  }

  ngOnInit(): void {
    this.createForm({
      fullName: [null, [], this.v.required.bind(this)],
      email: [null, [], this.v.required.bind(this)],
      password: [null, [], this.v.required.bind(this)],
      mobile: [null, [], this.v.mobile.bind(this)],
      designation: [null, [], this.v.required.bind(this)],
      media: [],
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
          const message = this._translate.instant('Member Registration Request Successfull');
          this.success(message);
          this.form.reset();
          this.photoUrl = '';
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


  handlePhotoChange(e) {
    const file = e.target.files[0];
    if (file) {
      this.photoLoading = true;
      var fr = new FileReader();
      fr.onload = () => {
        this.photoUrl = fr.result;
      }
      fr.readAsDataURL(file);
      this.mediaHttpService.upload(file, true,
        progress => {
          this.log('progress', progress);
        },
        success => {
          this.log('success', success);
          this.form.controls.media.setValue(success.data);
          this.photoLoading = false;
        },
        error => {
          this.photoLoading = false;
        }
      );
    }
  }

}
