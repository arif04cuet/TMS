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
import { BedHttpService } from 'src/services/http/hostel/bed-http.service';
import { RoomHttpService } from 'src/services/http/hostel/room-http.service';

@Component({
  selector: 'app-batch-schedule-allocation-add',
  templateUrl: './batch-schedule-allocation-add.component.html'
})
export class BatchScheduleAllocationAddComponent extends FormComponent {

  loading: boolean = true;
  selectedBed = null;
  selectedRoom = null;

  @ViewChild('batchScheduleSelect') batchScheduleSelect: SelectControlComponent;
  @ViewChild('courseSelect') courseSelect: SelectControlComponent;
  @ViewChild('traineeSelect') traineeSelect: SelectControlComponent;
  @ViewChild('statusSelect') statusSelect: SelectControlComponent;
  @ViewChild('bedSelect') bedSelect: SelectControlComponent;
  @ViewChild('roomSelect') roomSelect: SelectControlComponent;

  constructor(
    private activatedRoute: ActivatedRoute,
    private batchScheduleHttpService: BatchScheduleHttpService,
    private batchScheduleAllocationHttpService: BatchScheduleAllocationHttpService,
    private courseHttpService: CourseHttpService,
    private userHttpService: UserHttpService,
    private bedHttpService: BedHttpService,
    private roomHttpService: RoomHttpService,
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
      allocationDate: [],
      bed: [],
      room: []
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  ngAfterViewInit() {
    this.batchScheduleSelect.register((pagination, search) => {
      return this.batchScheduleHttpService.list(pagination, search);
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

    this.bedSelect.register((pagination, search) => {
      search += `&Search=IsBooked eq false`;
      return this.bedHttpService.list(pagination, search);
    }).fetch();

    this.roomSelect.register((pagination, search) => {
      search += `&Search=IsBooked eq false`;
      return this.roomHttpService.list(pagination, search);
    }).fetch();

  }

  submit(): void {
    if (this.isAddMode()) {
      this.form.controls.appliedDate.setValue(new Date());
    }

    const body: any = this.constructObject(this.form.controls);

    if (body.bed && body.room) {
      this.failed('bed.and.room.both.can.not.be.choose');
      return;
    }

    //add allocationDate to current date if status is approved
    if (body.status == 2 && !Boolean(body.allocationDate)) {
      body.allocationDate = new Date().toJSON("yyyy/MM/dd HH:mm");
    }

    //check participant duplikacy
    this.batchScheduleAllocationHttpService.list(null, this.getSearch()).subscribe((res: any) => {
      console.log(this.id, res.data.items);

      if (res.data.items.length && this.isAddMode()) {
        this.failed('participant.already.added');
        return;
      } else if (res.data.items.length && this.isEditMode() && (res.data.items[0]?.id != this.id)) {
        console.log('okk');
        this.failed('participant.already.added');
        return;
      }
      else {

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
    });


  }

  get(id) {
    this.loading = true;
    if (id != null) {
      this.subscribe(this.batchScheduleAllocationHttpService.get(id),
        (res: any) => {
          this.setValues(this.form.controls, res.data);
          if (res?.data?.bed?.id) {
            this.setValue('bed', res.data.bed.id);
          }
          this.selectedBed = res.data.bed;
          this.loading = false;

          //for edit mode show allocated bed in list with others available bed
          if (res.data.bed)
            this.bedSelect.items.push(res.data.bed);
          if (res.data.room)
            this.roomSelect.items.push(res.data.room);
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
  getSearch() {

    let search = '';
    if (this.courseSelect?.value) {
      search += `Search=CourseId eq ${this.courseSelect.value}&`;
    }
    if (this.batchScheduleSelect?.value) {
      search += `Search=BatchScheduleId eq ${this.batchScheduleSelect.value}&`;
    }
    if (this.traineeSelect?.value) {
      search += `Search=TraineeId eq ${this.traineeSelect.value}`;
    }

    return search;
  }

}
