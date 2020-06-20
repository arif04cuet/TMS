import { Component, ViewChild } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { UserHttpService } from 'src/services/http/user/user-http.service';
import { BatchScheduleHttpService } from 'src/services/http/budget-and-schedule/batch-schedule-http.service';
import { CourseHttpService } from 'src/services/http/course/course-http.service';
import { BatchScheduleAllocationHttpService } from 'src/services/http/budget-and-schedule/batch-schedule-allocation-http.service';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-batch-schedule-allocation-add',
  templateUrl: './batch-schedule-allocation-add.component.html'
})
export class BatchScheduleAllocationAddComponent extends FormComponent {

  loading: boolean = true;
  @ViewChild('batchScheduleSelect') batchScheduleSelect: SelectControlComponent;
  @ViewChild('courseSelect') courseSelect: SelectControlComponent;
  @ViewChild('traineeSelect') traineeSelect: SelectControlComponent;
  @ViewChild('statusSelect') statusSelect: SelectControlComponent;

  constructor(
    private activatedRoute: ActivatedRoute,
    private batchScheduleHttpService: BatchScheduleHttpService,
    private batchScheduleAllocationHttpService: BatchScheduleAllocationHttpService,
    private courseHttpService: CourseHttpService,
    private userHttpService: UserHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit(): void {
    this.onCheckMode = id => this.get(id);
    this.createForm({
      batchSchedule: [null, [], this.v.required.bind(this)],
      course: [null, [], this.v.required.bind(this)],
      trainee: [null, [], this.v.required.bind(this)],
      status: [null, [], this.v.required.bind(this)],
      appliedDate: [],
      allocationDate: []
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  ngAfterViewInit() {
    this.batchScheduleSelect.register((pagination, search) => {
      return this.batchScheduleHttpService.list(pagination, search).pipe(
        map((x: any) => {
          if(x.data && x.data.items && x.data.items.length) {
            x.data.items.forEach(item => {
              item.name = item.courseSchedule.name; 
            });
          }
          return x;
        })
      );
    }).fetch();

    this.courseSelect.register((pagination, search) => {
      return this.courseHttpService.list(pagination, search);
    }).fetch();

    this.traineeSelect.register((pagination, search) => {
      return this.userHttpService.list(pagination, search);
    }).fetch();

    this.statusSelect.register((pagination, search) => {
      return this.batchScheduleAllocationHttpService.listStatus();
    }).fetch();

  }

  submit(): void {
    if (this.isAddMode()) {
      this.form.controls.appliedDate.setValue(new Date());
    }
    const body = this.constructObject(this.form.controls);
    this.submitForm(
      {
        request: this.batchScheduleAllocationHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.batchScheduleAllocationHttpService.edit(this.id, body),
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
      this.subscribe(this.batchScheduleAllocationHttpService.get(id),
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
    this.goTo('/admin/trainings/batch-schedules/allocations');
  }

}
