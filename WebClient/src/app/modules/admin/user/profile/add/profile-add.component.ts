import { Component } from '@angular/core';
import { UserHttpService } from 'src/services/http/user-http.service';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { FormControl } from '@angular/forms';
import { of, forkJoin, Observable, Observer } from 'rxjs';
import { CommonHttpService } from 'src/services/http/common-http.service';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
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
      mobile: [],
      dateOfBirth: [],
      joiningDate: [],
      gender: [],
      maritalStatus: [],
      religion: [],
      bloodGroup: [],
      nid: [],
      password: [],
      confirmPassword: [],

      officeName: [],
      officeAddressLine1: [],
      officeAddressLine2: [],

      educationDegree: [],
      educationUniversity: [],
      educationDepartment: [],
      educationPassingYear: [],
      educationResult: [],

      contactAddressLine1: [],
      contactAddressLine2: [],
      contactUpazila: [],
      contactDistrict: []
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  submit(): void {
    this.markModeAsEdit();
    const o: any = this.constructObject(this.form.controls);
    this.mapRequestObject(o);
    this.submitForm(
      null,
      {
        request: this.userHttpService.updateProfile(this.userId, o),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_UPDATED);
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
        this.mapResponseObject(res[4].data);
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

  private mapResponseObject(data) {
    if (data) {
      this.setValue('gender', data.gender?.id);
      this.setValue('bloodGroup', data.bloodGroup?.id);
      this.setValue('maritalStatus', data.maritalStatus?.id);
      this.setValue('religion', data.religion?.id);
      if (data.officeAddress) {
        this.setValue('officeName', data.officeAddress.contactName);
        this.setValue('officeAddressLine1', data.officeAddress.addressLine1);
        this.setValue('officeAddressLine2', data.officeAddress.addressLine2);
      }
      if (data.contactAddress) {
        this.setValue('contactAddressLine1', data.contactAddress.addressLine1);
        this.setValue('contactAddressLine2', data.contactAddress.addressLine2);
        this.setValue('contactUpazila', data.contactAddress.upazila?.id);
        this.setValue('contactDistrict', data.contactAddress.district?.id);
      }
      if (data.educations && data.educations.length > 0) {
        const e = data.educations[0];
        this.setValue('educationDegree', e.degree);
        this.setValue('educationUniversity', e.university);
        this.setValue('educationDepartment', e.department);
        this.setValue('educationPassingYear', e.passingYear);
        this.setValue('educationResult', e.result);
      }
    }
  }

  private mapRequestObject(o) {
    o.userId = this.userId;
    o.contactAddress = {
      addressLine1: o.contactAddressLine1,
      addressLine2: o.contactAddressLine2,
      upazila: o.contactUpazila,
      district: o.contactDistrict
    };
    o.officeAddress = {
      contactName: o.officeName,
      addressLine1: o.officeAddressLine1,
      addressLine2: o.officeAddressLine2
    };
    o.educations = [{
      degree: o.educationDegree,
      University: o.educationUniversity,
      department: o.educationDepartment,
      passingYear: o.educationPassingYear,
      result: o.educationResult
    }];
  }

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
        return this.error(MESSAGE_KEY.THIS_FIELD_IS_REQUIRED);
      }
      else if (control.value.length < 4) {
        return this.error(MESSAGE_KEY.MUST_BE_EQUAL_OR_GREATER_THAN_4_CHARACTERS);
      }
    }
    return of(true);
  }


}
