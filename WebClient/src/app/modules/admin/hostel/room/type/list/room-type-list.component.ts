import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { environment } from 'src/environments/environment';
import { RoomTypeHttpService } from 'src/services/http/hostel/room-type-http.service';

@Component({
  selector: 'app-room-type-list',
  templateUrl: './room-type-list.component.html'
})
export class RoomTypeListComponent extends TableComponent {

  @Searchable("Name", "like") name;

  serverUrl = environment.serverUri;

  constructor(
    private roomTypeHttpService: RoomTypeHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(roomTypeHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/hostels/rooms/types/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/hostels/rooms/types/add');
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
