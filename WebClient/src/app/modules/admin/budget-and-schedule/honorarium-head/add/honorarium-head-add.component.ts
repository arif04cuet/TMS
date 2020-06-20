import { Component, ViewChild, ViewChildren, QueryList } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { HonorariumHeadHttpService } from 'src/services/http/budget-and-schedule/honorarium-head-http.service';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { DesignationHttpService } from 'src/services/http/user/designation-http.service';
import { forEachObj } from 'src/services/utilities.service';
import { AbstractControl, FormArray, FormControl } from '@angular/forms';
import { of } from 'rxjs';

@Component({
  selector: 'app-honorarium-head-add',
  templateUrl: './honorarium-head-add.component.html'
})
export class HonorariumHeadAddComponent extends FormComponent {

  loading: boolean = true;
  headType;
  @ViewChild('honorariumForSelect') honorariumForSelect: SelectControlComponent;
  @ViewChildren('designationSelect') designationSelects: QueryList<SelectControlComponent>;

  constructor(
    private activatedRoute: ActivatedRoute,
    private honorariumHeadHttpService: HonorariumHeadHttpService,
    private designationHttpService: DesignationHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit(): void {
    this.onCheckMode = id => this.get(id);
    this.createForm({
      honorariumFor: [null, [], this.v.required.bind(this)],
      year: [null, [], this.v.required.bind(this)],
      heads: this.fb.array([])
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  ngAfterViewInit() {

    this.honorariumForSelect.register((pagination, search) => {
      return this.honorariumHeadHttpService.honorariumForTypes();
    }).fetch();

    this.subscribe(this.designationSelects.changes, (selects: QueryList<SelectControlComponent>) => {
      if (this.isAddMode()) {
        selects.last.register((pagination, search) => {
          return this.designationHttpService.list(pagination, search);
        }).fetch();
      }
      else {
        selects.forEach(select => {
          select.register((pagination, search) => {
            return this.designationHttpService.list(pagination, search);
          }).fetch();
        });
      }
    });

  }

  submit(): void {
    const body: any = this.constructObject(this.form.controls);
    if (this.headType == 2) {
      if (body.heads.length > 0) {
        body.heads.forEach(head => {
          delete head.designation;
        });
      }
    }
    this.submitForm(
      {
        request: this.honorariumHeadHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.honorariumHeadHttpService.edit(this.id, body),
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
      this.subscribe(this.honorariumHeadHttpService.get(id),
        (res: any) => {
          this.setValues(this.form.controls, res.data, ["heads"]);
          if (res.data.honorariumFor) {
            this.headType = res.data.honorariumFor?.id;
          }
          else {
            this.setDefaultData();
          }
          this.prepareForm(res);
          this.loading = false;
        }
      );
    }
    else {
      this.loading = false;
      this.setDefaultData();
    }
  }

  cancel() {
    this.goTo('/admin/trainings/honorarium-heads');
  }

  onTypeChanged(e) {
    this.headType = e;
  }

  addHead() {
    this.createHeadFormGroup({});
  }

  deleteHead(index) {
    const headFormArray = this.getHeadFormArray();
    if (headFormArray.controls && headFormArray.controls.length) {
      headFormArray.removeAt(index);
    }
  }

  private prepareForm(res) {
    if (res.data && res.data.heads?.length) {
      res.data.heads.forEach(x => {
        this.createHeadFormGroup(x);
      });
    }
  }

  private createHeadFormGroup(data: any) {
    const formGroup = this.fb.group({
      id: [],
      designation: [null, [], this.designationRequired.bind(this)],
      head: [null, [], this.headRequired.bind(this)],
      amount: [null, [], this.v.required.bind(this)]
    });
    forEachObj(formGroup.controls, (k, v) => {
      const dataValue = data[k];
      this.setControlValue(v as AbstractControl, dataValue);
    });
    const headFormArray = this.getHeadFormArray();
    headFormArray.push(formGroup);
  }

  private getHeadFormArray(): FormArray {
    return this.form.get("heads") as FormArray;
  }

  headRequired(control: FormControl) {
    if (this.headType == 2 && !control.value) {
      return this.error(MESSAGE_KEY.THIS_FIELD_IS_REQUIRED);
    }
    return of(false);
  }

  designationRequired(control: FormControl) {
    if (this.headType == 1 && !control.value) {
      return this.error(MESSAGE_KEY.THIS_FIELD_IS_REQUIRED);
    }
    return of(false);
  }

  setDefaultData() {
    this.headType = 1;
    this.form.controls.honorariumFor.setValue(1);
  }

}
