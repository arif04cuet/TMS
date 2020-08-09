import { Component, Input } from '@angular/core';
import { TableComponent } from 'src/shared/table.component';
import { HotelHttpService } from 'src/services/hotel-http-service';


@Component({
  selector: 'app-hotel-and-room',
  templateUrl: './hotel-and-room.component.html',
  styleUrls:['./hotel-and-room.component.css']
})
export class HotelAndRoomComponent extends TableComponent {

  from;
  to;
  personCount="1";
  showTable=false;
  


  constructor(
    private hotelHttpService: HotelHttpService) {
    super(hotelHttpService);
  }

  ngOnInit(): void {
    this.loading = false;
  }

  search() {
    this.showTable=true;
    this.loading = true;
    this.load();
    
  }

}
