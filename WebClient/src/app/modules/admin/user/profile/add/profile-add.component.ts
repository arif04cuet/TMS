import { Component } from '@angular/core';
import { UserHttpService } from 'src/services/http/user-http.service';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { FormControl } from '@angular/forms';
import { of, forkJoin, Observable, Observer } from 'rxjs';
import { CommonHttpService } from 'src/services/http/common-http.service';
import { CommonValidator } from 'src/validators/common.validator';
import { MessageKey } from 'src/constants/message-key.constant';
import { UploadFile } from 'ng-zorro-antd/upload';
import { AuthService } from 'src/services/auth.service';

@Component({
  selector: 'app-profile-add',
  templateUrl: './profile-add.component.html',
  styleUrls: ['./profile-add.component.scss']
})
export class ProfileAddComponent extends FormComponent {

  loading: boolean = true;
  roles = [];
  designations = [];
  departments = [];
  statuses = [];
  genders = [];
  bloodGroups = [];
  maritalStatus = [];
  religions = [];

  photoUrl;
  photoLoading = false;

  private userId;

  constructor(
    private userHttpService: UserHttpService,
    private activatedRoute: ActivatedRoute,
    private commonHttpService: CommonHttpService,
    private v: CommonValidator,
    private authService: AuthService
  ) {
    super();
  }

  ngOnInit(): void {
    this.userId = this.authService.getLoggedInUserId();
    this.markModeAsEdit();
    this.getData();
    this.createForm({
      fullName: [null, [], this.v.required.bind(this)],
      designation: [null, [], this.v.required.bind(this)],
      department: [],
      mobile: [null, [], this.v.required.bind(this)],
      email: [null, [], this.v.required.bind(this)],
      roles: [null, [], this.v.required.bind(this)],
      status: [null, [], this.v.required.bind(this)],
      dateOfBirth: [null, [], this.v.required.bind(this)],
      joiningDate: [null, [], this.v.required.bind(this)],
      gender: [null, [], this.v.required.bind(this)],
      maritalStatus: [null, [], this.v.required.bind(this)],
      religion: [null, [], this.v.required.bind(this)],
      bloodGroup: [null, [], this.v.required.bind(this)],
      nid: [null, [], this.v.required.bind(this)],
      password: [null, [], this.v.required.bind(this)],
      confirmPassword: [null, [], this.v.required.bind(this)]
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  submit(): void {
    const body = this.constructObject(this.form.controls);
    this.submitForm(
      {
        request: this.userHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MessageKey.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.userHttpService.edit(this.id, body),
        succeed: res => {
          this.cancel();
          this.success(MessageKey.SUCCESSFULLY_UPDATED);
        }
      }
    );
  }

  get(id) {
    this.loading = true;
    if (this.mode == "edit") {
      this.form.controls.email.disable();
    }
    if (id != null) {
      this.subscribe(this.userHttpService.get(id),
        (res: any) => {
          this.setValues(this.form.controls, res.data);
          this.form.controls.status.setValue(res.data.status?.id);
          this.form.controls.designation.setValue(res.data.designation?.id);
          this.form.controls.department.setValue(res.data.department?.id);
          this.form.controls.roles.setValue(res.data.roles.map(x => x.id))
          this.loading = false;
        }
      );
    }
    else {
      this.form.controls.status.setValue(1);
      this.loading = false;
    }
  }

  cancel() {
    this.goTo('/admin/profile');
  }

  getData() {
    const requests = [
      this.commonHttpService.getGenders(),
      this.commonHttpService.getBloodGroups(),
      this.commonHttpService.getMaritalStatusList(),
      this.commonHttpService.getReligions(),
      this.userHttpService.getProfile(this.userId),
    ]
    this.subscribe(forkJoin(requests),
      (res: any[]) => {
        this.genders = res[0].data.items;
        this.bloodGroups = res[1].data.items;
        this.maritalStatus = res[2].data.items;
        this.religions = res[3].data.items;
        this.setValues(this.form.controls, res[4].data);
        this.loading = false;
      },
      (err: any) => {
        this.loading = false;
      }
    );
  }

  handlePhotoChange(info: { file: UploadFile }) {
    switch (info.file.status) {
      case 'uploading':
        this.photoLoading = true;
        break;
      case 'done':
        // Get this url from response in real world.
        this.getBase64(info.file!.originFileObj!, (img: string) => {
          this.photoLoading = false;
          this.photoUrl = img;
        });
        break;
      case 'error':
        this._messageService.error('Network error');
        this.photoLoading = false;
        break;
    }
  }

  beforePhotoUpload = (file: File) => {
    return new Observable((observer: Observer<boolean>) => {
      const isJPG = file.type === 'image/jpeg' || file.type === 'image/png';
      if (!isJPG) {
        this._messageService.error('You can only upload JPG file!');
        observer.complete();
        return;
      }
      const isLt2M = file.size / 1024 / 1024 < 2;
      if (!isLt2M) {
        this._messageService.error('Image must smaller than 2MB!');
        observer.complete();
        return;
      }
      // check height
      // this.checkImageDimension(file).then(dimensionRes => {
      //   if (!dimensionRes) {
      //     this._messageService.error('Image only 300x300 above');
      //     observer.complete();
      //     return;
      //   }

      //   observer.next(isJPG && isLt2M && dimensionRes);
      //   observer.complete();
      // });

      observer.next(isJPG && isLt2M);
      observer.complete();
    });
  };

  private getBase64(img: File, callback: (img: string) => void): void {
    const reader = new FileReader();
    reader.addEventListener('load', () => callback(reader.result!.toString()));
    reader.readAsDataURL(img);
  }

  private checkImageDimension(file: File): Promise<boolean> {
    return new Promise(resolve => {
      const img = new Image(); // create image
      img.src = window.URL.createObjectURL(file);
      img.onload = () => {
        const width = img.naturalWidth;
        const height = img.naturalHeight;
        window.URL.revokeObjectURL(img.src!);
        resolve(width === height && width >= 300);
      };
    });
  }

  private password(control: FormControl) {
    if (this.mode == 'add' || control.value) {
      if (!control.value) {
        return this.error(MessageKey.THIS_FIELD_IS_REQUIRED);
      }
      else if (control.value.length < 4) {
        return this.error(MessageKey.MUST_BE_EQUAL_OR_GREATER_THAN_4_CHARACTERS);
      }
    }
    return of(true);
  }


}
