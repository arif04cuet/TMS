import { Component, ViewChild } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { ResourcePersonHttpService } from 'src/services/http/course/resource-person-http.service';
import { DesignationHttpService } from 'src/services/http/user/designation-http.service';
import { ExpertiseHttpService } from 'src/services/http/course/expertise-http.service';
import { HonorariumHeadHttpService } from 'src/services/http/budget-and-schedule/honorarium-head-http.service';
import { MediaHttpService } from 'src/services/http/media-http.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-resource-person-add',
  templateUrl: './resource-person-add.component.html'
})
export class ResourcePersonAddComponent extends FormComponent {

  loading: boolean = true;
  data: any = {};

  photoUrl;
  photoLoading = false;

  cvUrl;
  cvFileName;
  cvLoading = false;



  @ViewChild('designationSelect') designationSelect: SelectControlComponent;
  @ViewChild('expertiseSelect') expertiseSelect: SelectControlComponent;
  @ViewChild('honorariumHeadSelect') honorariumHeadSelect: SelectControlComponent;

  constructor(
    private activatedRoute: ActivatedRoute,
    private resourcePersonHttpService: ResourcePersonHttpService,
    private designationHttpService: DesignationHttpService,
    private expertiseHttpService: ExpertiseHttpService,
    private honorariumHeadHttpService: HonorariumHeadHttpService,
    private v: CommonValidator,
    private mediaHttpService: MediaHttpService
  ) {
    super();
  }

  ngOnInit(): void {
    this.onCheckMode = id => this.get(id);
    this.createForm({
      name: [null, [], this.v.required.bind(this)],
      shortName: [null, [], this.v.required.bind(this)],
      designation: [null, [], this.v.required.bind(this)],
      email: [null, [], this.v.required.bind(this)],
      mobile: [null, [], this.v.required.bind(this)],
      nid: [],
      tin: [],
      altEmail: [],
      altMobile: [],
      mailingAddress: [],
      officeAddress: [],
      cv: [],
      photo: [],
      expertises: [],
      honorariumHead: [null, [], this.v.required.bind(this)],
      facebookUrl: [],
      isFacebookUrlPublic: [true],
      youTubeUrl: [],
      isYouTubeUrlPublic: [true],
      linkedinUrl: [],
      isLinkedinUrlPublic: [true],
      instagramUrl: [],
      isInstagramUrlPublic: [true]
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  ngAfterViewInit() {
    this.designationSelect.register((pagination, search) => {
      return this.designationHttpService.list(pagination, search);
    }).fetch();

    this.expertiseSelect.register((pagination, search) => {
      return this.expertiseHttpService.list(pagination, search);
    }).fetch();

    this.honorariumHeadSelect.register((pagination, search) => {
      return this.honorariumHeadHttpService.latestYearHonorariumHeads(pagination, search);
    }).fetch();
  }

  submit(): void {

    const body: any = this.constructObject(this.form.controls);
    if (!body.expertises) {
      body.expertises = [];
    }
    if(!body.cv) {
      delete body.cv;
    }
    if(!body.photo) {
      delete body.photo;
    }

    this.submitForm(
      {
        request: this.resourcePersonHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.resourcePersonHttpService.edit(this.id, body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_UPDATED);
        }
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
          this.form.controls.photo.setValue(success.data);
          this.photoLoading = false;
        },
        error => {
          this.photoLoading = false;
        }
      );
    }
  }

  handleCvChange(e) {
    const file = e.target.files[0];
    if (file) {
      this.cvLoading = true;
      var fr = new FileReader();
      fr.onload = () => {
        this.cvUrl = fr.result;
      }
      fr.readAsDataURL(file);
      this.mediaHttpService.upload(file, true,
        progress => {
          this.log('progress', progress);
        },
        success => {
          this.log('success', success);
          this.form.controls.cv.setValue(success.data);
          this.cvLoading = false;
        },
        error => {
          this.cvLoading = false;
        }
      );
    }
  }


  get(id) {
    this.loading = true;
    if (id != null) {
      this.subscribe(this.resourcePersonHttpService.get(id),
        (res: any) => {
          this.setValues(this.form.controls, res.data);
          this.loading = false;
          this.data = res.data;

          if (res.data.photo) {
            this.photoUrl = `${environment.serverUri}/${res.data.photo}`;
          }

          if (res.data.cv) {
            this.cvUrl = `${environment.serverUri}/${res.data.cv}`;
            this.cvFileName = res.data.cvFileName;
          }


        }
      );
    }
    else {
      this.loading = false;
    }
  }

  cancel() {
    this.goTo('/admin/courses/resource-persons');
  }

  delete(e) {

  }

}
