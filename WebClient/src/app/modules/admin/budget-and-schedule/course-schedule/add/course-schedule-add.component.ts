import { Component, ViewChild } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { CourseScheduleHttpService } from 'src/services/http/budget-and-schedule/course-schedule-http.service';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { DesignationHttpService } from 'src/services/http/user/designation-http.service';
import { CourseHttpService } from 'src/services/http/course/course-http.service';
import { UserHttpService } from 'src/services/http/user/user-http.service';
import { AbstractControl, FormArray, FormGroup } from '@angular/forms';
import { forEachObj } from 'src/services/utilities.service';
import { SelectComponent } from 'src/app/shared/select/select.component';

@Component({
  selector: 'app-course-schedule-add',
  templateUrl: './course-schedule-add.component.html'
})
export class CourseScheduleAddComponent extends FormComponent {

  loading: boolean = true;
  @ViewChild('courseSelect') courseSelect: SelectControlComponent;
  @ViewChild('coordinatorSelect') coordinatorSelect: SelectControlComponent;
  @ViewChild('coCoordinatorSelect') coCoordinatorSelect: SelectControlComponent;
  @ViewChild('eligibleForSelect') eligibleForSelect: SelectControlComponent;
  @ViewChild('staff1Select') staff1Select: SelectControlComponent;
  @ViewChild('staff2Select') staff2Select: SelectControlComponent;
  @ViewChild('staff3Select') staff3Select: SelectControlComponent;
  @ViewChild('budgetReuseSelect') budgetReuseSelect: SelectComponent;

  courseAddEditTitle;
  budgetAddEditTitle;
  detailsOptions = [];

  private budgetReUsing = false;

  constructor(
    private activatedRoute: ActivatedRoute,
    private courseScheduleHttpService: CourseScheduleHttpService,
    private designationHttpService: DesignationHttpService,
    private courseHttpService: CourseHttpService,
    private userHttpService: UserHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  async ngOnInit() {
    this.submitButtonText = '';
    this.onCheckMode = id => this.get(id);
    this.budgetReUsing = false;

    // course schedule form
    this.createForm({
      name: [],
      course: [null, [], this.v.required.bind(this)],
      coordinator: [null, [], this.v.required.bind(this)],
      coCoordinator: [null, [], this.v.required.bind(this)],
      eligibleFor: [null, [], this.v.required.bind(this)],
      totalSeat: [null, [], this.v.required.bind(this)],
      budgets: this.fb.array([]),
      total: [],
      staff1: [],
      staff2: [],
      staff3: [],
    });

    super.ngOnInit(this.activatedRoute.snapshot);

    const schedule = await this.t('course.schedule');
    const budget = await this.t('budget');
    if (this.mode == 'add') {
      this.courseAddEditTitle = await this.t('create.a.x0', { x0: schedule });
      this.budgetAddEditTitle = await this.t('create.a.x0', { x0: budget });
    }
    else if (this.mode == 'edit') {
      this.courseAddEditTitle = await this.t('update.a.x0', { x0: schedule });
      this.budgetAddEditTitle = await this.t('update.a.x0', { x0: budget });
    }
  }

  ngAfterViewInit() {
    this.budgetReuseSelect.register((pagination, search) => {
      return this.courseScheduleHttpService.listBudget(pagination, search);
    }).fetch();

    this.courseSelect.register((pagination, search) => {
      return this.courseHttpService.list(pagination, search);
    }).fetch();

    this.coordinatorSelect.register((pagination, search) => {
      return this.userHttpService.list(pagination, search);
    }).fetch();

    this.coCoordinatorSelect.register((pagination, search) => {
      return this.userHttpService.list(pagination, search);
    }).fetch();

    this.eligibleForSelect.register((pagination, search) => {
      return this.designationHttpService.list(pagination, search);
    }).fetch();

    this.staff1Select.register((pagination, search) => {
      return this.userHttpService.list(pagination, search);
    }).fetch();

    this.staff2Select.register((pagination, search) => {
      return this.userHttpService.list(pagination, search);
    }).fetch();

    this.staff3Select.register((pagination, search) => {
      return this.userHttpService.list(pagination, search);
    }).fetch();
  }

  submit(): void {
    const body = this.constructObject(this.form.controls);
    this.submitForm(
      {
        request: this.courseScheduleHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.courseScheduleHttpService.edit(this.id, body),
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
      this.subscribe(this.courseScheduleHttpService.get(id),
        (res: any) => {
          this.setValues(this.form.controls, res.data, ["budgets"]);
          this.prepareForm(res);
          this.loading = false;
        }
      );
    }
    else {
      this.loading = false;
    }
  }

  cancel() {
    this.goTo('/admin/trainings/course-schedules');
  }

  addBudget() {
    const serial = `${this.getBudgetFormArray().length + 1}`;
    this.createBudgetFormGroup({ serial: serial });
  }

  deleteBudget(index) {
    const budgetFormArray = this.getBudgetFormArray();
    if (budgetFormArray.controls && budgetFormArray.controls.length) {
      budgetFormArray.removeAt(index);
    }
  }

  prepareForm(res) {
    if (res.data && res.data.budgets?.length) {
      res.data.budgets.forEach(x => {
        if (x.items && x.items.length) {
          x.total = x.items.map(x => x.total).reduce((a, c) => a + c);
        }
        this.createBudgetFormGroup(x);
      });
      res.data.total = res.data.budgets.map(x => x.total).reduce((a, c) => a + c);
      this.form.controls.total.setValue(res.data.total);
    }
  }

  createBudgetFormGroup(data: any) {
    const formGroup = this.fb.group({
      id: [],
      serial: [null, [], this.v.required.bind(this)],
      category: [null, [], this.v.required.bind(this)],
      items: this.fb.array([]),
      total: []
    });
    forEachObj(formGroup.controls, (k, v) => {
      const dataValue = data[k];
      if (k == "items") {
        if (dataValue && dataValue.length) {
          dataValue.forEach(item => {
            this.createItemFormGroup(formGroup, item)
          });
        }
      }
      else {
        if (dataValue) {
          (v as AbstractControl).setValue(dataValue);
        }
      }
    });
    const budgetFormArray = this.getBudgetFormArray();
    budgetFormArray.push(formGroup);
  }

  getBudgetFormArray(): FormArray {
    return this.form.get("budgets") as FormArray;
  }

  getItemFormArray(formGroup: FormGroup): FormArray {
    return formGroup.get("items") as FormArray;
  }

  addItem(e: FormGroup, i) {
    const serial = `${i + 1}.${this.getItemFormArray(e).length + 1}`;
    this.createItemFormGroup(e, { serial: serial });
    this.calculateBudgetTotal(e);
  }

  deleteItem(index, formGroup: FormGroup) {
    const itemFormArray = this.getItemFormArray(formGroup);
    if (itemFormArray.controls && itemFormArray.controls.length) {
      itemFormArray.removeAt(index);
    }
    this.calculateBudgetTotal(formGroup);
  }

  async onBudgetReuseChanged(e) {
    const text = await this.t('loading.budget');
    const loading = this._messageService.loading(text);
    this.subscribe(this.courseScheduleHttpService.get(e),
      (res: any) => {
        this.getBudgetFormArray().clear();
        if (res && res.data && res.data.budgets?.length) {
          res.data.budgets = res.data.budgets.map(x => {
            delete x.id;
            if (x.items && x.items?.length) {
              x.items = x.items.map(y => {
                delete y.id;
                return y;
              });
            }
            return x;
          });
        }
        this.prepareForm(res);
        this._messageService.remove(loading.messageId);
      },
      err => {
        this._messageService.remove(loading.messageId);
      }
    );
  }

  createItemFormGroup(_formGroup: FormGroup, data: any) {
    const formGroup = this.fb.group({
      id: [],
      serial: [null, [], this.v.required.bind(this)],
      details: [null, [], this.v.required.bind(this)],
      rate: [null, [], this.v.required.bind(this)],
      quantity: [null, [], this.v.required.bind(this)],
      total: [],
    });
    forEachObj(formGroup.controls, (k, v) => {
      const dataValue = data[k];
      if (dataValue) {
        (v as AbstractControl).setValue(dataValue);
      }
    });
    const itemFormArray = this.getItemFormArray(_formGroup);
    itemFormArray.push(formGroup);
  }

  calculateTotal(formGroup: FormGroup) {
    if (formGroup) {
      const rate = formGroup.controls.rate.value || 0;
      const qty = formGroup.controls.quantity.value || 0;
      const total = rate * qty;
      formGroup.controls.total.setValue(total);
      this.calculateBudgetTotal(formGroup.parent.parent as FormGroup);
    }
  }

  calculateBudgetTotal(budgetFormGroup: FormGroup) {
    if (budgetFormGroup) {
      const total = budgetFormGroup.controls.items.value.map(x => x.total).reduce((a, c) => a + c);
      budgetFormGroup.controls.total.setValue(total);
    }
    const total = this.form.controls.budgets.value.map(x => x.total).reduce((a, c) => a + c);
    this.form.controls.total.setValue(total);
  }

  onDetailsInput(e) {
    this.detailsOptions = [];
    this.subscribe(this.courseScheduleHttpService.detailsAutocomplete(e),
      (res: any) => {
        this.detailsOptions = res.data;
      },
      err => {
        this.detailsOptions = [];
      });
  }

  onSelectDetails(option, item) {
    item.controls.rate.setValue(option.rate);
  }

}
