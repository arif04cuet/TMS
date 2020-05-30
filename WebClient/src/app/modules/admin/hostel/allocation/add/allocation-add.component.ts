import { Component, ViewChild, Type, TemplateRef } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { HostelHttpService } from 'src/services/http/hostel/hostel-http.service';
import { AllocationHttpService } from 'src/services/http/hostel/allocation-http.service';
import { UserHttpService } from 'src/services/http/user/user-http.service';
import { BedModalComponent } from '../bed-modal/bed-modal.component';
import { NzModalService } from 'ng-zorro-antd';
import { RoomModalComponent } from '../room-modal/room-modal.component';

@Component({
  selector: 'app-allocation-add',
  templateUrl: './allocation-add.component.html'
})
export class AllocationAddComponent extends FormComponent {

  loading: boolean = true;
  roomOrBed = 'bed';
  additionalInfo: any;

  @ViewChild('userSelect') userSelect: SelectControlComponent;
  @ViewChild("modalFooter") modalFooter: TemplateRef<any>;

  constructor(
    private activatedRoute: ActivatedRoute,
    private allocationHttpService: AllocationHttpService,
    private userHttpService: UserHttpService,
    private hostelHttpService: HostelHttpService,
    private v: CommonValidator,
    private modal: NzModalService
  ) {
    super();
  }

  ngOnInit(): void {
    this.onCheckMode = id => this.get(id);
    this.createForm({
      checkinDate: [null, [], this.v.required.bind(this)],
      roomOrBed: [this.roomOrBed],
      participant: [null, [], this.v.required.bind(this)],
      room: [],
      bed: []
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  ngAfterViewInit() {
    this.userSelect.register((pagination, search) => {
      return this.userHttpService.list(pagination, search);
    }).fetch();
  }

  submit(): void {
    const body = this.constructObject(this.form.controls);
    this.submitForm(
      {
        request: this.allocationHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.allocationHttpService.edit(this.id, body),
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
      this.subscribe(this.allocationHttpService.get(id),
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
    this.goTo('/admin/hostels/allocations');
  }

  optionChange(e) {
    this.roomOrBed = e;
  }

  selectRoom() {
    const modal = this.createModal(RoomModalComponent);
    this.subscribe(modal.afterClose, res => {
      this.additionalInfo = modal.getContentComponent().selectedRoom;
      if(this.additionalInfo) {
        this.form.controls.bed.setValue(null);
        this.form.controls.room.setValue(this.additionalInfo.id);
      }
    });
  }

  selectBed() {
    const modal = this.createModal(BedModalComponent);
    this.subscribe(modal.afterClose, res => {
      this.additionalInfo = modal.getContentComponent().selectedBed;
      if(this.additionalInfo) {
        this.form.controls.bed.setValue(this.additionalInfo.id);
        this.form.controls.room.setValue(null);
      }
    });
  }

  createModal<T>(component: Type<T>) {
    return this.modal.create({
      nzWidth: '80%',
      nzContent: component,
      nzGetContainer: () => document.body,
      nzComponentParams: {
        // title: 'title in component',
        // subtitle: 'component sub title，will be changed after 2 sec'
      },
      nzFooter: this.modalFooter
    });
  }

}
