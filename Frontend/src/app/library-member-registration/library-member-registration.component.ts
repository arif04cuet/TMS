import { Component, ViewChild } from '@angular/core';
import { Validators } from '@angular/forms';
import { FormComponent } from 'src/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { LibraryHttpService } from 'src/services/library-http-service';

@Component({
  selector: 'app-library-member-registration',
  templateUrl: './library-member-registration.component.html',
  styleUrls: ['./library-member-registration.component.css']
})
export class LibraryMemberRegistrationComponent extends FormComponent {

  libraries = []

  constructor(
    private libraryHttpService: LibraryHttpService) {
    super();
  }

  ngOnInit(): void {
    this.createForm({
      fullName: [null, [Validators.required]],
      email: [null, [Validators.email, Validators.required]],
      password: [null, [Validators.required]],
      mobile: [null, [Validators.required]],
      library: [null, [Validators.required]],
      agree: []
    });
    this.markModeAsAdd();
    this.getData();
  }

  submit(): void {
    const body: any = this.constructObject(this.form.controls);
    this.submitForm(
      {
        request: this.libraryHttpService.registration(body),
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
    this.subscribe(this.libraryHttpService.list(null, null),
      (res: any) => {
        this.libraries = res.data.items
      }
    );
  }

}
