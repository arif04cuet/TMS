import { Component, ViewChild } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { environment } from 'src/environments/environment';
import { RoomHttpService } from 'src/services/http/hostel/room-http.service';
import { SelectComponent } from 'src/app/shared/select/select.component';
import { RoomTypeHttpService } from 'src/services/http/hostel/room-type-http.service';
import { IButton } from 'src/app/shared/table-actions.component';

@Component({
  selector: 'app-room-list',
  templateUrl: './room-list.component.html'
})
export class RoomListComponent extends TableComponent {

  @ViewChild('roomType') roomType: SelectComponent;
  @Searchable("Name", "like") name;
  serverUrl = environment.serverUri;

  buttons: IButton[] = [
    {
      label: 'edit',
      action: d => this.add(d),
      permissions: ['room.manage', 'room.update'],
      icon: 'edit'
    },
    {
      label: 'delete',
      action: d => this.delete(d),
      permissions: ['room.manage', 'room.delete'],
      icon: 'delete'
    }
  ]

  constructor(
    private roomHttpService: RoomHttpService,
    private activatedRoute: ActivatedRoute,
    private roomTypeHttpService: RoomTypeHttpService,
  ) {
    super(roomHttpService);
  }

  ngOnInit() {

    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
  }

  ngAfterViewInit() {
    this.roomType.register((pagination, search) => {
      return this.roomTypeHttpService.list(pagination, search);
    }).fetch();

  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/hostels/rooms/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/hostels/rooms/add');
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

}
