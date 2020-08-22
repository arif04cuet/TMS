import { Component, ViewChild } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { forEachObj } from 'src/services/utilities.service';
import { AbstractControl, FormArray } from '@angular/forms';
import { UserHttpService } from 'src/services/http/user/user-http.service';
import { RequisitionHttpService } from 'src/services/http/asset/requisition-http.service';
import { BatchScheduleHttpService } from 'src/services/http/budget-and-schedule/batch-schedule-http.service';

@Component({
  selector: 'app-requisition-add',
  templateUrl: './requisition-add.component.html'
})
export class RequisitionAddComponent extends FormComponent {

  loading: boolean = true;
  statuses = [];

  @ViewChild('userSelect') userSelect: SelectControlComponent;
  @ViewChild('batchSelect') batchSelect: SelectControlComponent;
  
  photoUrl;

  constructor(
    private activatedRoute: ActivatedRoute,
    private requisitionHttpService: RequisitionHttpService,
    private userHttpService: UserHttpService,
    private batchScheduleHttpService: BatchScheduleHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit(): void {
    this.onCheckMode = id => this.get(id);
    this.createForm({
      title: [null, [], this.v.required.bind(this)],
      currentApprover: [],
      batchSchedule: [],
      items: this.fb.array([])
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  ngAfterViewInit() {

    this.userSelect.register((pagination, search) => {
      return this.userHttpService.list(pagination, search);
    }).fetch();

    this.batchSelect.register((pagination, search) => {
      return this.batchScheduleHttpService.list(pagination, search);
    }).fetch();

  }

  submit(): void {
    const body: any = this.constructObject(this.form.controls);
    if (this.id) {
      body.id = Number(this.id);
    }
    // const items = (this.form.controls.items as any).controls.length;
    // if (!items || items <= 0) {
    //   this.info('please.add.at.least.one.item');
    //   return;
    // }
    this.submitForm(
      {
        request: this.requisitionHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        },
        failed: res => {
          if (res.error
            && res.error.message == "form_error"
            && res.error.data.length
            && res.error.data[0].field == "Items") {
            this._messageService.error(res.error.data[0].message);
          }
        }
      },
      {
        request: this.requisitionHttpService.edit(this.id, body),
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
      this.subscribe(this.requisitionHttpService.get(id),
        (res: any) => {
          this.setValues(this.form.controls, res.data, ['items']);
          this.form.controls.items = this.fb.array([]);
          this.prepareForm(res);
          this.loading = false;
        }
      );
    }
    else {
      //this.form.controls.isActive.setValue(true);
      this.loading = false;

    }
  }

  cancel() {
    this.goTo('/admin/asset/my-requisitions');
  }

  addItem() {
    this.createItemFormGroup({});
  }

  deleteItem(index) {
    const itemFormArray = this.getItemFormArray();
    if (itemFormArray.controls && itemFormArray.controls.length) {
      itemFormArray.removeAt(index);
    }
  }

  private prepareForm(res) {
    if (res.data && res.data.Items?.length) {
      res.data.Items.forEach(x => {
        this.createItemFormGroup(x);
      });
    }
  }

  private createItemFormGroup(data: any) {
    const formGroup = this.fb.group({
      assetTag: [null, [], this.v.required.bind(this)],
      itemNo: [],
      purchaseCost: [null, [], this.v.required.bind(this)],
      isRequestable: [false],
      warranty: [],
      maintenance: [],
      depreciation: [null, [], this.v.required.bind(this)],
      media: [],
      status: [null, [], this.v.required.bind(this)],
      assetModel: [null, [], this.v.required.bind(this)]
    });
    forEachObj(formGroup.controls, (k, v) => {
      const dataValue = data[k];
      if (dataValue) {
        (v as AbstractControl).setValue(dataValue);
      }
    });
    const itemFormArray = this.getItemFormArray();
    itemFormArray.push(formGroup);
  }

  private getItemFormArray(): FormArray {
    return this.form.get("items") as FormArray;
  }

}
