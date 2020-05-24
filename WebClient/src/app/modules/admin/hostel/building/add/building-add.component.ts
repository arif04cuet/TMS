import { Component, ViewChild } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { BuildingHttpService } from 'src/services/http/hostel/building-http.service';
import { forEachObj } from 'src/services/utilities.service';
import { AbstractControl, FormArray } from '@angular/forms';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { HostelHttpService } from 'src/services/http/hostel/hostel-http.service';

@Component({
  selector: 'app-building-add',
  templateUrl: './building-add.component.html'
})
export class BuildingAddComponent extends FormComponent {

  loading: boolean = true;

  @ViewChild('hostelSelect') hostelSelect: SelectControlComponent;

  constructor(
    private activatedRoute: ActivatedRoute,
    private buildingHttpService: BuildingHttpService,
    private hostelHttpService: HostelHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit(): void {
    this.onCheckMode = id => this.get(id);
    this.createForm({
      name: [null, [], this.v.required.bind(this)],
      hostel: [null, [], this.v.required.bind(this)],
      floors: this.fb.array([])
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  ngAfterViewInit() {
    this.hostelSelect.register((pagination, search) => {
      return this.hostelHttpService.list(pagination, search);
    }).fetch();
  }

  submit(): void {
    const body = this.constructObject(this.form.controls);
    this.submitForm(
      {
        request: this.buildingHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.buildingHttpService.edit(this.id, body),
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
      this.subscribe(this.buildingHttpService.get(id),
        (res: any) => {
          this.setValues(this.form.controls, res.data, ['floors']);
          this.form.controls.floors = this.fb.array([]);
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
    this.goTo('/admin/hostels/buildings');
  }

  addFloor() {
    this.createFloorFormGroup({});
  }

  deleteFloor(index) {
    const floorFormArray = this.getFloorFormArray();
    if (floorFormArray.controls && floorFormArray.controls.length) {
      floorFormArray.removeAt(index);
    }
  }

  private prepareForm(res) {
    if (res.data && res.data.floors?.length) {
      res.data.floors.forEach(x => {
        this.createFloorFormGroup(x);
      });
    }
  }

  private createFloorFormGroup(data: any) {
    const formGroup = this.fb.group({
      id: [],
      name: [null, [], this.v.required.bind(this)]
    });
    forEachObj(formGroup.controls, (k, v) => {
      const dataValue = data[k];
      if (dataValue) {
        (v as AbstractControl).setValue(dataValue);
      }
    });
    const floorFormArray = this.getFloorFormArray();
    floorFormArray.push(formGroup);
  }

  private getFloorFormArray(): FormArray {
    return this.form.get("floors") as FormArray;
  }

}
