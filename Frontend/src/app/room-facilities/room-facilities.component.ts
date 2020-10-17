import { Component, Input } from '@angular/core';
import { FormComponent } from 'src/shared/form.component';
import { RegistrationHttpService } from 'src/services/registration-http-service';

import { RoomFacilitiesHttpService } from 'src/services/room-facilities-http-service';
import { TableComponent } from 'src/shared/table.component';

@Component({
  selector: 'app-room-facilities',
  templateUrl: './room-facilities.component.html',
  styleUrls: ['./room-facilities.component.css']
})
export class RoomFacilitiesComponent extends TableComponent {

  @Input() number: number = 5;
  items = [];

  constructor(private facilitiesHttpService: RoomFacilitiesHttpService) {
    super(facilitiesHttpService);
  }

  ngOnInit(): void {
    this.getData();
  }

  getData() {
    const pagination = `limit=${this.number}`;
    this.subscribe(this.facilitiesHttpService.list(pagination),
      (res: any) => {
        this.items = res.data.items
      }
    );
  }

}
