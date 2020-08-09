import { Component, Input } from '@angular/core';
import { TableComponent } from 'src/shared/table.component';
import { HotelHttpService } from 'src/services/hotel-http-service';


@Component({
  selector: 'app-hotel-and-room',
  templateUrl: './hotel-and-room.component.html'
})
export class HotelAndRoomComponent extends TableComponent {

  from;
  to;

  constructor(
    private hotelHttpService: HotelHttpService) {
    super(hotelHttpService);
  }

  ngOnInit(): void {
    this.loading = false;
  }

  search() {
    this.loading = true;
    this.load();
  }

}
