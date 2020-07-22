import { Component, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TableComponent } from 'src/app/shared/table.component';
import { BedHttpService } from 'src/services/http/hostel/bed-http.service';
import { HostelHttpService } from 'src/services/http/hostel/hostel-http.service';
import { SelectComponent } from 'src/app/shared/select/select.component';
import { NzModalService } from 'ng-zorro-antd';
import { RoomHttpService } from 'src/services/http/hostel/room-http.service';
import { RoomTypeHttpService } from 'src/services/http/hostel/room-type-http.service';

@Component({
  selector: 'app-room-modal',
  templateUrl: './room-modal.component.html'
})
export class RoomModalComponent extends TableComponent {

  @ViewChild('hostelSelect') hostelSelect: SelectComponent;
  @ViewChild('buildingSelect') buildingSelect: SelectComponent;
  @ViewChild('floorSelect') floorSelect: SelectComponent;
  @ViewChild('roomTypeSelect') roomTypeSelect: SelectComponent;

  selectedRoom;

  constructor(
    private roomHttpService: RoomHttpService,
    private roomTypeHttpService: RoomTypeHttpService,
    private hostelHttpService: HostelHttpService,
    private activatedRoute: ActivatedRoute,
    private modal: NzModalService
  ) {
    super(roomHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
  }

  ngAfterViewInit() {
    this.hostelSelect.register((pagination, search) => {
      return this.hostelHttpService.list(pagination, search);
    }).fetch();

    this.roomTypeSelect.register((pagination, search) => {
      return this.roomTypeHttpService.list(pagination, search);
    }).fetch();
  }

  onHostelChanged(e) {
    this.buildingSelect.register((pagination, search) => {
      return this.hostelHttpService.listBuildings(e, pagination, search);
    }).fetch(null, true);
  }

  onBuildingChanged(e) {
    const hostel = this.hostelSelect.value;
    if (hostel) {
      this.floorSelect.register((pagination, search) => {
        return this.hostelHttpService.listFloors(hostel, e, pagination, search);
      }).fetch(null, true);
    }
  }

  gets() {
    this.load();
  }

  refresh() {
    this.load();
  }

  search() {
    this.load();
  }

  load() {
    super.load((p, s) => {
      let search = this.getSearchTerm('hostel');
      search += this.getSearchTerm('building');
      search += this.getSearchTerm('floor');
      search += this.getSearchTerm('roomType');
      search += `&Search=IsBooked eq false`;
      return this.roomHttpService.list(p, search);
    });
  }

  select(e) {
    this.selectedRoom = e;
    this.modal.closeAll();
  }

  getSearchTerm(selectName: string) {
    const select = this[`${selectName}Select`];
    if (select) {
      const value = select.value;
      const prop = selectName.charAt(0).toUpperCase() + selectName.slice(1)
      if (value) {
        return `&Search=${prop}Id eq ${value}`;
      }
    }
    return '';
  }

}
