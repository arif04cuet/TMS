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
import { NzModalRef, NzModalService } from 'ng-zorro-antd';
import { RoomModalComponent } from '../room-modal/room-modal.component';
import { RoomHttpService } from 'src/services/http/hostel/room-http.service';
import { BedHttpService } from 'src/services/http/hostel/bed-http.service';
import { of } from 'rxjs';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-allocation-add',
  templateUrl: './allocation-add.component.html'
})
export class AllocationAddComponent extends FormComponent {

  loading: boolean = true;
  roomOrBed = 'bed';
  additionalInfo: any;

  @ViewChild('userSelect') userSelect: SelectControlComponent;
  @ViewChild('statusSelect') statusSelect: SelectControlComponent;
  @ViewChild("modalFooter") modalFooter: TemplateRef<any>;

  private modalRef: NzModalRef<any>;

  constructor(
    private activatedRoute: ActivatedRoute,
    private allocationHttpService: AllocationHttpService,
    private userHttpService: UserHttpService,
    private hostelHttpService: HostelHttpService,
    private roomHttpService: RoomHttpService,
    private bedHttpService: BedHttpService,
    private v: CommonValidator,
    private modal: NzModalService
  ) {
    super();
  }

  async ngOnInit() {
    this.onCheckMode = id => this.get(id);
    this.createForm({
      checkinDate: [null, [], this.checkingValidation.bind(this)],
      roomOrBed: [this.roomOrBed],
      participant: [null, [], this.v.required.bind(this)],
      room: [],
      bed: [],
      // checkoutDate: [null, [], this.onEditValidation.bind(this)],
      // days: [null, [], this.onEditValidation.bind(this)],
      // amount: [null, [], this.onEditValidation.bind(this)],
      status: [null, [], this.v.required.bind(this)]
    });
    super.ngOnInit(this.activatedRoute.snapshot);

    if(this.isAddMode()) {
      this.submitButtonText = await this.t('checkin');
    }
    else if (this.isEditMode()) {
      this.submitButtonText = await this.t('update');
    }
  }

  ngAfterViewInit() {
    this.userSelect.register((pagination, search) => {
      return this.userHttpService.list(pagination, search);
    }).fetch();

    this.statusSelect.register((pagination, search) => {
      return of({
        data: this.getStatus()
      });
    }).fetch();
  }

  submit(): void {
    if (!this.additionalInfo) {
      this.failed('please.select.room.or.bed');
      return;
    }
    const body: any = this.constructObject(this.form.controls);
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
          let roomOrBed = 'bed';
          if (res.data.room) {
            roomOrBed = 'room';
          }
          this.setValue('roomOrBed', roomOrBed);
          if (res.data.bed) {
            this.subscribe(this.bedHttpService.get(res.data.bed.id),
              (res: any) => {
                this.additionalInfo = res.data;
                this.loading = false;
              },
              err => {
                this.loading = false;
              });
          }
          else if (res.data.room) {
            this.subscribe(this.roomHttpService.get(res.data.room.id),
              (res: any) => {
                this.additionalInfo = res.data;
                this.loading = false;
              },
              err => {
                this.loading = false;
              });
          }
          this.setValues(this.form.controls, res.data);
          this.setValue('participant', res.data.user?.id);
          this.loading = false;
        }
      );
    }
    else {
      // add mode
      this.setValue('roomOrBed', 'bed');
      this.form.controls.status.setValue(2);
      this.loading = false;
    }
  }

  cancel() {
    this.goTo('/admin/hostels/allocations');
  }

  optionChange(e) {
    this.roomOrBed = e;
    this.additionalInfo = null;
    this.form.controls.bed.setValue(null);
    this.form.controls.room.setValue(null);
  }

  selectRoom() {
    this.modalRef = this.createModal(RoomModalComponent);
    this.subscribe(this.modalRef.afterClose, res => {
      this.additionalInfo = this.modalRef.getContentComponent().selectedRoom;
      if (this.additionalInfo) {
        this.form.controls.bed.setValue(null);
        this.form.controls.room.setValue(this.additionalInfo.id);
      }
    });
  }

  selectBed() {
    this.modalRef = this.createModal(BedModalComponent);
    this.subscribe(this.modalRef.afterClose, res => {
      this.additionalInfo = this.modalRef.getContentComponent().selectedBed;
      if (this.additionalInfo) {
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
      nzComponentParams: {},
      nzFooter: this.modalFooter
    });
  }

  checkoutValidation(control: FormControl) {
    if (this.isEditMode()) {
      return this.v.required(control);
    }
    return of(true);
  }

  onEditValidation(control: FormControl) {
    if (this.isEditMode()) {
      if (!control.value) {
        return this.error(MESSAGE_KEY.THIS_FIELD_IS_REQUIRED);
      }
    }
    return of(null);
  }

  checkingValidation(control: FormControl) {
    const status = this.form?.controls?.status?.value;
    if (status != 1 && !control.value) {
      return this.error(MESSAGE_KEY.THIS_FIELD_IS_REQUIRED);
    }
    return of(null);
  }

  onCheckoutDate(e) {
    if(!e)
      return;

    const checkout = e.toISOString();
    this.subscribe(this.allocationHttpService.getRent(this.id, checkout),
      (res: any) => {
        if(res.data) {
          this.setValue('days', res.data.days);
          this.setValue('amount', res.data.amount);
        }
      },
      err => { }
    );
  }

  closeModal() {
    if(this.modalRef) {
      this.modalRef.close();
    }
  }

  private getStatus() {
    const status = this.form.controls.status.value;
    if (this.isAddMode()) {
      return {
        items: [
          { id: 1, name: 'Temporary Booked' },
          { id: 2, name: 'Booked' }
        ],
        size: 2
      }
    }
    else if (status == 1 || status == 2) {
      return {
        items: [
          { id: 1, name: 'Temporary Booked' },
          { id: 2, name: 'Booked' },
          { id: 3, name: 'Cancelled' }
        ],
        size: 3
      }
    }
    else if (status == 3) {
      return {
        items: [{ id: 3, name: 'Cancelled' }],
        size: 1
      }
    }
    return {
      items: [
        { id: 1, name: 'Temporary Booked' },
        { id: 2, name: 'Booked' }
      ],
      size: 2
    };
  }

}
