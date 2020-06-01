import { Component, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TableComponent } from 'src/app/shared/table.component';
import { BedHttpService } from 'src/services/http/hostel/bed-http.service';
import { HostelHttpService } from 'src/services/http/hostel/hostel-http.service';
import { SelectComponent } from 'src/app/shared/select/select.component';
import { NzModalService } from 'ng-zorro-antd';

@Component({
  selector: 'app-bed-modal',
  templateUrl: './bed-modal.component.html'
})
export class BedModalComponent extends TableComponent {

  @ViewChild('hostelSelect') hostelSelect: SelectComponent;
  @ViewChild('buildingSelect') buildingSelect: SelectComponent;
  @ViewChild('floorSelect') floorSelect: SelectComponent;
  @ViewChild('roomSelect') roomSelect: SelectComponent;

  selectedBed;

  constructor(
    private bedHttpService: BedHttpService,
    private hostelHttpService: HostelHttpService,
    private activatedRoute: ActivatedRoute,
    private modal: NzModalService
  ) {
    super(bedHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
  }

  ngAfterViewInit() {
    this.hostelSelect.register((pagination, search) => {
      return this.hostelHttpService.list(pagination, search);
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

  onFloorChanged(e) {
    const hostel = this.hostelSelect.value;
    const building = this.buildingSelect.value;
    if (hostel && building) {
      this.roomSelect.register((pagination, search) => {
        return this.hostelHttpService.listRooms(hostel, building, e, pagination, search);
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
      search += this.getSearchTerm('room');
      search += `&Search=IsBooked eq false`;
      return this.bedHttpService.list(p, search);
    });
  }

  select(e) {
    this.selectedBed = e;
    this.log('selected bed', e);
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
