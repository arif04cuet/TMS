import { Component, ViewChild } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { OfficeHttpService } from 'src/services/http/user/office-http.service';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { CommonHttpService } from 'src/services/http/common-http.service';

@Component({
  selector: 'app-office-add',
  templateUrl: './office-add.component.html'
})
export class OfficeAddComponent extends FormComponent {

  loading: boolean = true;

  @ViewChild('divisionSelect') divisionSelect: SelectControlComponent;
  @ViewChild('districtSelect') districtSelect: SelectControlComponent;
  @ViewChild('upazilaSelect') upazilaSelect: SelectControlComponent;

  constructor(
    private officeHttpService: OfficeHttpService,
    private commonHttpService: CommonHttpService,
    private activatedRoute: ActivatedRoute,
    private v: CommonValidator
  ) {
    super();
  }

  async ngOnInit() {
    this.onCheckMode = id => this.get(id);
    this.createForm({
      officeName: [null, [], this.v.required.bind(this)],
      addressLine1: [null, [], this.v.required.bind(this)],
      addressLine2: [],
      division: [],
      district: [],
      upazila: [],
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  submit(): void {
    const body: any = this.constructObject(this.form.controls);
    this.submitForm(
      {
        request: this.officeHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.officeHttpService.edit(this.id, body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_UPDATED);
        }
      }
    );
  }

  ngAfterViewInit() {
    this.divisionSelect.register((pagination, search) => {
      return this.commonHttpService.getAllDistrict();
    }).fetch();

    this.districtSelect.register((pagination, search) => {
      return this.commonHttpService.getAllDistrict();
    }).fetch();

    this.upazilaSelect.register((pagination, search) => {
      return this.commonHttpService.getAllDistrict();
    }).fetch();
  }

  get(id) {
    this.loading = true;
    if (id != null) {
      this.subscribe(this.officeHttpService.get(id),
        (res: any) => {
          this.setValues(this.form.controls, res.data);
          this.loading = false;
        }
      );
    }
    else {
      this.loading = false;
    }
  }

  cancel() {
    this.goTo('/admin/offices');
  }

}
