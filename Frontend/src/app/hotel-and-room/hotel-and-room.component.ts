import { Component, Input } from '@angular/core';
import { TableComponent } from 'src/shared/table.component';
import { HotelHttpService } from 'src/services/hotel-http-service';


@Component({
  selector: 'app-hotel-and-room',
  templateUrl: './hotel-and-room.component.html',
  styleUrls: ['./hotel-and-room.component.css']
})
export class HotelAndRoomComponent extends TableComponent {

  from;
  to;
  personCount = "1";
  showTable = false;
  searchResult = [];



  constructor(
    private hotelHttpService: HotelHttpService) {
    super(hotelHttpService);
  }

  ngOnInit(): void {
    this.loading = false;
  }

  search() {

    this.getData();

  }

  getData() {
    this.loading = true;
    this.subscribe(this.hotelHttpService.list(),
      (res: any) => {

        this.items = res.data.items

        this.searchResult = [];
        for (let i = 0; i < this.items.length; i++) {
          const item = this.items[i];

          var existingItemIndex = this.searchResult.findIndex(function (x) { return x.name === item.name });

          if (existingItemIndex !== -1) {
            //increament bed number
            var existingItem = this.searchResult[existingItemIndex];
            existingItem.bedCount = existingItem.bedCount + 1;
            this.searchResult[existingItemIndex] = existingItem;
          } else {
            this.searchResult.push(item);
          }


        }

        this.showTable = this.searchResult.reduce(function (acc, x) { return acc + x.bedCount }, 0) > this.personCount;
        this.loading = false;

      }
    );
  }

}
