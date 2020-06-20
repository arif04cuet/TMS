import { Component, ViewChild } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { CourseScheduleHttpService } from 'src/services/http/budget-and-schedule/course-schedule-http.service';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { UserHttpService } from 'src/services/http/user/user-http.service';
import { BatchScheduleHttpService } from 'src/services/http/budget-and-schedule/batch-schedule-http.service';
import { BroadcastService } from 'src/services/broadcast.service';

@Component({
  selector: 'app-batch-schedule-add',
  templateUrl: './batch-schedule-add.component.html'
})
export class BatchScheduleAddComponent extends FormComponent {

  loading: boolean = true;
  @ViewChild('courseScheduleSelect') courseScheduleSelect: SelectControlComponent;
  @ViewChild('coordinatorSelect') coordinatorSelect: SelectControlComponent;
  @ViewChild('coCoordinatorSelect') coCoordinatorSelect: SelectControlComponent;

  batchScheduleAddEditTitle;
  private currentSelectedTab;

  constructor(
    private activatedRoute: ActivatedRoute,
    private courseScheduleHttpService: CourseScheduleHttpService,
    private batchScheduleHttpService: BatchScheduleHttpService,
    private userHttpService: UserHttpService,
    private v: CommonValidator,
    private broadcastService: BroadcastService
  ) {
    super();
  }

  async ngOnInit() {
    this.onCheckMode = id => this.get(id);
    this.createForm({
      courseSchedule: [null, [], this.v.required.bind(this)],
      totalSeat: [null, [], this.v.required.bind(this)],
      startDate: [null, [], this.v.required.bind(this)],
      endDate: [null, [], this.v.required.bind(this)],
      registrationStartDate: [null, [], this.v.required.bind(this)],
      registrationEndDate: [null, [], this.v.required.bind(this)],
      coordinator: [null, [], this.v.required.bind(this)],
      coCoordinator: [null, [], this.v.required.bind(this)],
    });
    super.ngOnInit(this.activatedRoute.snapshot);

    const schedule = await this.t('batch.schedule');
    const createA = 'create.a.x0';
    const updateA = 'update.a.x0';
    if(this.isAddMode()) {
      this.batchScheduleAddEditTitle = await this.t(createA, {x0: schedule});
    }
    else {
      this.batchScheduleAddEditTitle = await this.t(updateA, {x0: schedule});
    }
  }

  ngAfterViewInit() {
    this.courseScheduleSelect.register((pagination, search) => {
      return this.courseScheduleHttpService.list(pagination, search);
    }).fetch();

    this.coordinatorSelect.register((pagination, search) => {
      return this.userHttpService.list(pagination, search);
    }).fetch();

    this.coCoordinatorSelect.register((pagination, search) => {
      return this.userHttpService.list(pagination, search);
    }).fetch();

  }

  submit(): void {
    if(this.currentSelectedTab && this.currentSelectedTab.index != 0) {
      this.broadcastService.broadcast('batch_schedule_update');
      return;
    }
    const body = this.constructObject(this.form.controls);
    this.submitForm(
      {
        request: this.batchScheduleHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.batchScheduleHttpService.edit(this.id, body),
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
      this.subscribe(this.batchScheduleHttpService.get(id),
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
    this.goTo('/admin/trainings/batch-schedules');
  }

  tabChanged(e) {
    this.currentSelectedTab = e;
    this.log('tab changed', e);
  }

}
