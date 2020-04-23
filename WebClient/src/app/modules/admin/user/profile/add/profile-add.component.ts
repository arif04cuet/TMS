import { Component } from '@angular/core';
import { UserHttpService } from 'src/services/http/user-http.service';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { FormControl } from '@angular/forms';
import { of, forkJoin, } from 'rxjs';
import { CommonHttpService } from 'src/services/http/common-http.service';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { AuthService } from 'src/services/auth.service';
import { MediaHttpService } from 'src/services/http/media-http.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-profile-add',
  templateUrl: './profile-add.component.html'
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
  districts = [];

  photoUrl;
  photoLoading = false;

  private userId;

  constructor(
    private userHttpService: UserHttpService,
    private activatedRoute: ActivatedRoute,
    private commonHttpService: CommonHttpService,
    private v: CommonValidator,
    private authService: AuthService,
    private mediaHttpService: MediaHttpService
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
      media: [],

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
      this.commonHttpService.getDistricts()
    ]
    this.subscribe(forkJoin(requests),
      (res: any[]) => {
        this.genders = res[0].data.items;
        this.bloodGroups = res[1].data.items;
        this.maritalStatus = res[2].data.items;
        this.religions = res[3].data.items;
        this.districts = res[5].data.items;
        this.setValues(this.form.controls, res[4].data);
        this.mapResponseObject(res[4].data);
        this.loading = false;
      },
      (err: any) => {
        this.loading = false;
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

  private mapResponseObject(data) {
    if (data) {
      if(data.photo) {
        this.photoUrl = `${environment.serverUri}/${data.photo}`;
      }
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
      if (data.education) {
        const e = data.education;
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
    o.education = {
      degree: o.educationDegree,
      University: o.educationUniversity,
      department: o.educationDepartment,
      passingYear: o.educationPassingYear,
      result: o.educationResult
    };
  }

  private getBase64(img: File, callback: (img: string) => void): void {
    const reader = new FileReader();
    reader.addEventListener('load', () => callback(reader.result!.toString()));
    reader.readAsDataURL(img);
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
