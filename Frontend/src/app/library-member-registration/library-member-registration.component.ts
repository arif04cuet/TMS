import { Component, ViewChild } from '@angular/core';
import { Validators } from '@angular/forms';
import { FormComponent } from 'src/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { LibraryHttpService } from 'src/services/library-http-service';
import { MediaHttpService } from 'src/services/media-http.service';

@Component({
  selector: 'app-library-member-registration',
  templateUrl: './library-member-registration.component.html',
  styleUrls: ['./library-member-registration.component.css']
})
export class LibraryMemberRegistrationComponent extends FormComponent {

  libraries = []
  photoUrl;
  photoLoading = false;


  constructor(
    private libraryHttpService: LibraryHttpService,
    private mediaHttpService: MediaHttpService) {
    super();
  }

  ngOnInit(): void {
    this.createForm({
      fullName: [null, [Validators.required]],
      email: [null, [Validators.required, Validators.email]],
      password: [null, [Validators.required]],
      mobile: [null, [Validators.required]],
      library: [null, [Validators.required]],
      agree: [],
      media: [],
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
          const message = this._translate.instant('Library Member Registration Request Successfull');
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
    this.subscribe(this.libraryHttpService.list(null, null),
      (res: any) => {
        var first_item;
        const items = res.data.items;
        for (let index = 0; index < items.length; ++index) {
          var library = items[index];
          if (library.name.includes('all') || library.name.includes('সকল')) {
            first_item = library;
          }
          else
            this.libraries.push(library);
        }

        this.libraries.unshift(first_item);

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
