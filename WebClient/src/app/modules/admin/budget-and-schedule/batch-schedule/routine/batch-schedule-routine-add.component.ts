import { Component, ViewChildren, QueryList } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { CourseScheduleHttpService } from 'src/services/http/budget-and-schedule/course-schedule-http.service';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { BatchScheduleHttpService } from 'src/services/http/budget-and-schedule/batch-schedule-http.service';
import { forEachObj } from 'src/services/utilities.service';
import { AbstractControl, FormArray, FormGroup } from '@angular/forms';
import { ResourcePersonHttpService } from 'src/services/http/course/resource-person-http.service';
import { ModuleHttpService } from 'src/services/http/course/module-http.service';
import { BatchScheduleRoutineHttpService } from 'src/services/http/budget-and-schedule/batch-schedule-routine.http.service';
import { forkJoin } from 'rxjs';
import { BroadcastService } from 'src/services/broadcast.service';
import { TopicHttpService } from 'src/services/http/course/topic-http.service';

@Component({
  selector: 'app-batch-schedule-routine-add',
  templateUrl: './batch-schedule-routine-add.component.html'
})
export class BatchScheduleRoutineAddComponent extends FormComponent {

  loading: boolean = true;
  @ViewChildren('moduleSelect') moduleSelect: QueryList<SelectControlComponent>;
  @ViewChildren('topicSelect') topicSelect: QueryList<SelectControlComponent>;
  @ViewChildren('resourcePersonSelect') resourcePersonSelect: QueryList<SelectControlComponent>;

  batchScheduleId;
  classRoutineId;
  courseModuleCount;
  data;

  persons = [1, 2]

  constructor(
    private activatedRoute: ActivatedRoute,
    private courseScheduleHttpService: CourseScheduleHttpService,
    private moduleHttpService: ModuleHttpService,
    private resourcePersonHttpService: ResourcePersonHttpService,
    private batchScheduleHttpService: BatchScheduleHttpService,
    private batchScheduleRoutineHttpService: BatchScheduleRoutineHttpService,
    private topicHttpService: TopicHttpService,
    private v: CommonValidator,
    private broadcastService: BroadcastService
  ) {
    super();
  }

  async ngOnInit() {
    this.createForm({
      modules: this.fb.array([])
    });
    const snapshot = this.activatedRoute.snapshot;
    this.batchScheduleId = snapshot.params.id;
    this.get(this.batchScheduleId);

    this.subscribe(this.broadcastService.on('batch_schedule_update'), d => {
      this.submit();
    });
  }

  ngAfterViewInit() {

    console.log('rendered');
    this.subscribe(this.moduleSelect.changes, (selects: QueryList<SelectControlComponent>) => {
      selects.forEach(select => {
        if (!select.items.length) {
          select.register((pagination, search) => {
            return this.batchScheduleHttpService.listModules(this.batchScheduleId, pagination, search);
          }).fetch();
        }
      });
    });

    this.subscribe(this.topicSelect.changes, (selects: QueryList<SelectControlComponent>) => {
      selects.forEach(select => {
        if (!select.items.length) {
          if (select.name) {
            const moduleIndex = Number(select.name.replace("module_", ""))
            const moduleId = this.moduleSelect.toArray()[moduleIndex].value;
            if (moduleId) {
              select.register((pagination, search) => {
                return this.moduleHttpService.listTopics(moduleId, pagination, search);
              }).fetch();
            }
            else {
              this.warning('please.select.a.module');
            }
          }
        }
      });
    });

    this.subscribe(this.resourcePersonSelect.changes, (selects: QueryList<SelectControlComponent>) => {
      selects.forEach(select => {
        let fn;
        const topicId = select.name.topic.value;
        const selectControl = select.name.select as SelectControlComponent
        selectControl.onLoadCompleted(() => {
          //console.log('changed=' + topicId);
        })

        if (topicId) {
          // get topic resource persons
          fn = (pagination, search) => {
            return this.topicHttpService.listResourcePersons(topicId);
          }
        }
        else {
          // get all resource persons
          // fn = (pagination, search) => {
          //   return this.resourcePersonHttpService.list(pagination, search);
          // }
        }
        if (!select.items.length)
          select.register(fn).fetch();

      });
    });

  }

  submit(): void {
    const body: any = this.constructObject(this.form.controls);
    if (body && this.classRoutineId) {
      body.id = Number(this.classRoutineId);
    }
    if (this.batchScheduleId) {
      body.batchSchedule = Number(this.batchScheduleId);
    }
    if (!this.classRoutineId) {
      this.create({
        request: this.batchScheduleRoutineHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      });
    }
    else {
      this.update({
        request: this.batchScheduleRoutineHttpService.edit(this.classRoutineId, body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_UPDATED);
        }
      });
    }
  }

  get(id) {
    this.loading = true;
    this.markModeAsAdd();
    if (id != null) {
      const pagination = 'offset=0&limit=1000';
      const requests = forkJoin([
        this.batchScheduleHttpService.get(id),
        this.batchScheduleRoutineHttpService.list(id, pagination)
      ])
      this.subscribe(requests,
        (res: any) => {
          this.courseModuleCount = res[0]?.data.modules?.length;
          if (res[1].data.items && res[1].data.items.length) {
            this.classRoutineId = res[1].data.items[0].id;
            this.markModeAsEdit();
          }
          this.prepareForm(this.courseModuleCount, res[1]?.data?.items);
          this.loading = false;
        },
        err => {
          this.loading = false;
        }
      );
    }
    else {
      this.loading = false;
    }
  }

  cancel() {
    this.goTo('/admin/trainings/batch-schedules');
  }

  moduleChanged(e, moduleIndex) {
    const moduleKey = `module_${moduleIndex}`
    const topicSelects = this.topicSelect.toArray().filter(x => x.name == moduleKey);
    if (topicSelects) {
      topicSelects.forEach(select => {
        select.items = [];
        select.register((pagination, search) => {
          return this.moduleHttpService.listTopics(e, pagination, search);
        }).fetch();
      });
    }
  }

  topicChanged(e, periodIndex) {
    //console.log(e.target.value);
    const topicId = e;
    const resourcePersonSelects = this.resourcePersonSelect.toArray().filter(x => x.name.period == periodIndex);
    if (resourcePersonSelects) {
      resourcePersonSelects.forEach(select => {
        select.items = [];
        select.register((pagination, search) => {
          //return this.resourcePersonHttpService.list(pagination, search);
          return this.topicHttpService.listResourcePersons(topicId);
        }).fetch();
      });
    }
  }

  prepareForm(moduleCount, data) {
    for (let i = 0; i < moduleCount; i++) {
      let module = {};
      if (data.length && data[0]?.modules.length && data[0]?.modules.length > i) {
        module = data[0].modules[i];
      }
      this.createModuleFormGroup(module);
    }
  }

  createModuleFormGroup(data: any = {}) {
    const formGroup = this.fb.group({
      id: [],
      module: [null, [], this.v.required.bind(this)],
      routines: this.fb.array([])
    });
    forEachObj(formGroup.controls, (k, v) => {
      const dataValue = data[k];
      if (k == "routines") {
        if (dataValue && dataValue.length) {
          dataValue.forEach(item => {
            this.createRoutineFormGroup(formGroup, item)
          });
        }
      }
      else {
        if (dataValue) {
          (v as AbstractControl).setValue(dataValue);
        }
      }
    });
    const moduleFormArray = this.getModuleFormArray();
    moduleFormArray.push(formGroup);
  }

  getModuleFormArray(): FormArray {
    return this.form.get("modules") as FormArray;
  }

  createRoutineFormGroup(moduleFormGroup: FormGroup, data: any = {}) {
    const formGroup = this.fb.group({
      id: [],
      trainingDate: [null, [], this.v.required.bind(this)],
      periods: this.fb.array([])
    });
    forEachObj(formGroup.controls, (k, v) => {
      const dataValue = data[k];
      if (k == "periods") {
        if (dataValue && dataValue.length) {
          dataValue.forEach(item => {
            this.createPeriodFormGroup(formGroup, item)
          });
        }
      }
      else {
        if (dataValue) {
          (v as AbstractControl).setValue(dataValue);
        }
      }
    });
    const routineFormArray = this.getRoutineFormArray(moduleFormGroup);
    routineFormArray.push(formGroup);
  }

  getRoutineFormArray(moduleFormGroup: FormGroup): FormArray {
    return moduleFormGroup.get("routines") as FormArray;
  }

  createPeriodFormGroup(routineFormGroup: FormGroup, data: any = {}) {
    const formGroup = this.fb.group({
      id: [],
      topic: [null, [], this.v.required.bind(this)],
      startTime: [null, [], this.v.required.bind(this)],
      endTime: [null, [], this.v.required.bind(this)],
      resourcePerson: [null, [], this.v.required.bind(this)]
    });
    forEachObj(formGroup.controls, (k, v) => {
      const dataValue = data[k];
      if (dataValue) {
        if (k == "endTime" || k == "startTime") {
          const arr = dataValue.split(":");
          const h = Number(arr[0]);
          const m = Number(arr[1]);
          const s = Number(arr[2]);
          (v as AbstractControl).setValue(new Date(0, 0, 0, h, m, s));
        }
        else {
          (v as AbstractControl).setValue(dataValue);
        }
      }
    });
    const periodFormArray = this.getPeriodFormArray(routineFormGroup);
    periodFormArray.push(formGroup);
  }

  getPeriodFormArray(routineFormGroup: FormGroup): FormArray {
    return routineFormGroup.get("periods") as FormArray;
  }

  addPeriod(routineFormGroup: FormGroup) {
    this.createPeriodFormGroup(routineFormGroup);
  }

  addRoutine(moduleFormGroup: FormGroup) {
    this.createRoutineFormGroup(moduleFormGroup);
  }

  deletePeriod(index, routineFormGroup) {
    const periodFormArray = this.getPeriodFormArray(routineFormGroup);
    if (periodFormArray.controls && periodFormArray.controls.length) {
      periodFormArray.removeAt(index);
    }
  }

  deleteRoutine(index, moduleFormGroup) {
    const routineFormArray = this.getRoutineFormArray(moduleFormGroup);
    if (routineFormArray.controls && routineFormArray.controls.length) {
      routineFormArray.removeAt(index);
    }
  }

}
