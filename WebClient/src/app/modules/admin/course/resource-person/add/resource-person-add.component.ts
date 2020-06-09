import { Component, ViewChild, Type, TemplateRef } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { ResourcePersonHttpService } from 'src/services/http/course/resource-person-http.service';
import { DesignationHttpService } from 'src/services/http/user/designation-http.service';
import { ExpertiseHttpService } from 'src/services/http/course/expertise-http.service';

@Component({
  selector: 'app-resource-person-add',
  templateUrl: './resource-person-add.component.html'
})
export class ResourcePersonAddComponent extends FormComponent {

  loading: boolean = true;
  data: any = {};

  @ViewChild('designationSelect') designationSelect: SelectControlComponent;
  @ViewChild('expertiseSelect') expertiseSelect: SelectControlComponent;

  constructor(
    private activatedRoute: ActivatedRoute,
    private resourcePersonHttpService: ResourcePersonHttpService,
    private designationHttpService: DesignationHttpService,
    private expertiseHttpService: ExpertiseHttpService,
    private v: CommonValidator
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
      nid: [null, [], this.v.required.bind(this)],
      tin: [null, [], this.v.required.bind(this)],
      expertises: [],
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
  }

  submit(): void {

    const body: any = this.constructObject(this.form.controls);
    if (!body.expertises) {
      body.expertises = [];
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

  get(id) {
    this.loading = true;
    if (id != null) {
      this.subscribe(this.resourcePersonHttpService.get(id),
        (res: any) => {
          this.setValues(this.form.controls, res.data);
          this.loading = false;
          this.data = res.data;
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
