import { Component, ViewChild } from '@angular/core';
import { FormComponent } from 'src/app/shared/form.component';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { RoomHttpService } from 'src/services/http/hostel/room-http.service';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';
import { RoomTypeHttpService } from 'src/services/http/hostel/room-type-http.service';
import { BuildingHttpService } from 'src/services/http/hostel/building-http.service';
import { HostelHttpService } from 'src/services/http/hostel/hostel-http.service';
import { FacilitiesHttpService } from 'src/services/http/hostel/facilities-http.service';
import { forEachObj } from 'src/services/utilities.service';
import { AbstractControl, FormArray } from '@angular/forms';
import { MediaHttpService } from 'src/services/http/media-http.service';
import { map, catchError } from 'rxjs/operators';
import { of } from 'rxjs';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-room-add',
  templateUrl: './room-add.component.html'
})
export class RoomAddComponent extends FormComponent {

  loading: boolean = true;

  imageUrl;
  imageLoading = false;

  @ViewChild('typeSelect') typeSelect: SelectControlComponent;
  @ViewChild('buildingSelect') buildingSelect: SelectControlComponent;
  @ViewChild('floorSelect') floorSelect: SelectControlComponent;
  @ViewChild('facilitiesSelect') facilitiesSelect: SelectControlComponent;

  private data: any;

  constructor(
    private activatedRoute: ActivatedRoute,
    private roomHttpService: RoomHttpService,
    private roomTypeHttpService: RoomTypeHttpService,
    private buildingHttpService: BuildingHttpService,
    private hostelHttpService: HostelHttpService,
    private facilitiesHttpService: FacilitiesHttpService,
    private mediaHttpService: MediaHttpService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit(): void {
    this.onCheckMode = id => this.get(id);
    this.createForm({
      name: [null, [], this.v.required.bind(this)],
      roomType: [null, [], this.v.required.bind(this)],
      building: [null, [], this.v.required.bind(this)],
      floor: [null, [], this.v.required.bind(this)],
      facilities: [],
      beds: this.fb.array([]),
      image: []
    });
    super.ngOnInit(this.activatedRoute.snapshot);
  }

  ngAfterViewInit() {
    this.typeSelect.register((pagination, search) => {
      return this.roomTypeHttpService.list(pagination, search);
    }).fetch();

    this.buildingSelect.register((pagination, search) => {
      return this.buildingHttpService.list(pagination, search).pipe(
        map((x: any) => {
          x.data.items.forEach(o => {
            o.name = `${o.name} - ${o.hostel.name}`
          });
          return x;
        })
      );
    }).onLoadCompleted(() => {
        if (this.isEditMode()) {
          this.onBuildingChanged(this.form.controls.building.value);
        }
      })
      .fetch();

    this.facilitiesSelect.register((pagination, search) => {
      return this.facilitiesHttpService.list(pagination, search);
    }).fetch();
  }

  submit(): void {
    const body: any = this.constructObject(this.form.controls);
    const hostel = this.getHostelByBuildingId(this.form.controls.building.value);
    if (hostel) {
      body.hostel = hostel.id;
    }
    if (!body.image) {
      delete body.image;
    }
    this.submitForm(
      {
        request: this.roomHttpService.add(body),
        succeed: res => {
          this.cancel();
          this.success(MESSAGE_KEY.SUCCESSFULLY_CREATED);
        }
      },
      {
        request: this.roomHttpService.edit(this.id, body),
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
      this.subscribe(this.roomHttpService.get(id),
        (res: any) => {
          this.data = res.data;
          this.setValues(this.form.controls, res.data, ['beds']);
          this.setValue('roomType', res.data.type?.id);
          this.form.controls.beds = this.fb.array([]);
          this.prepareForm(res);
          this.loading = false;
          if (res.data.imageUrl) {
            this.imageUrl = `${environment.serverUri}/${res.data.imageUrl}`;
          }
        }
      );
    }
    else {
      this.loading = false;
    }
  }

  cancel() {
    this.goTo('/admin/hostels/rooms');
  }

  onBuildingChanged(e) {
    let hostel: any = this.getHostelByBuildingId(e);
    if(!hostel && this.isEditMode() && this.data) {
      hostel = this.data.hostel;
    }
    if (hostel) {
      this.floorSelect.register((pagination, search) => {
        return this.hostelHttpService.listFloors(hostel.id, e, pagination, search);
      }).fetch(null, true);
    }
  }

  addBed() {
    this.createBedFormGroup({});
  }

  deleteBed(index) {
    const bedFormArray = this.getBedFormArray();
    if (bedFormArray.controls && bedFormArray.controls.length) {
      bedFormArray.removeAt(index);
    }
  }

  private getHostelByBuildingId(id) {
    return this.buildingSelect.items.find(x => x.id == id)?.hostel;
  }

  private prepareForm(res) {
    if (res.data && res.data.beds?.length) {
      res.data.beds.forEach(x => {
        this.createBedFormGroup(x);
      });
    }
  }

  private createBedFormGroup(data: any) {
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
    const bedFormArray = this.getBedFormArray();
    bedFormArray.push(formGroup);
  }

  private getBedFormArray(): FormArray {
    return this.form.get("beds") as FormArray;
  }

  imageDeleteHandler = imageId => {
    return this.roomHttpService
      .deleteImage(imageId, this.id || null)
      .pipe(
        map(x => {
          console.log('course image delete', x);
          return true
        }),
        catchError(_ => of(false))
      );
  }

}
