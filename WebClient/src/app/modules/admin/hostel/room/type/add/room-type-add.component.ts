import { Component, ViewChild } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { RoomTypeHttpService } from 'src/services/http/hostel/room-type-http.service';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { DesignationHttpService } from 'src/services/http/user/designation-http.service';

@Component({
  selector: 'app-room-type-add',
  templateUrl: './room-type-add.component.html'
})
export class RoomTypeAddComponent extends FormComponent {

  loading: boolean = true;

  @ViewChild('designationSelect') designationSelect: SelectControlComponent;

  constructor(
    private activatedRoute: ActivatedRoute,
    private roomTypeHttpService: RoomTypeHttpService,
    private designationHttpService: DesignationHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit(): void {
    this.onCheckMode = id => this.get(id);
    this.createForm({
      name: [null, [], this.v.required.bind(this)],
      rent: [null, [], this.v.required.bind(this)],
      designation: [],
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  ngAfterViewInit() {
    this.designationSelect.register((pagination, search) => {
      return this.designationHttpService.list();
    }).fetch();
  }

  submit(): void {
    const body = this.constructObject(this.form.controls);
    this.submitForm(
      {
        request: this.roomTypeHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.roomTypeHttpService.edit(this.id, body),
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
      this.subscribe(this.roomTypeHttpService.get(id),
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
    this.goTo('/admin/hostels/rooms/types');
  }

}
