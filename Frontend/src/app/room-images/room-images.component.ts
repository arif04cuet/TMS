import { Component, Input } from '@angular/core';
import { CmsHttpService } from '../../services/cms-http-service';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { TableComponent } from 'src/shared/table.component';
import { RoomHttpService } from 'src/services/room-http.service';

@Component({
  selector: 'app-room-images',
  templateUrl: './room-images.component.html',
  styleUrls: ['./room-images.component.css']
})
export class RoomImagesComponent extends TableComponent {

  @Input() count: number = 3;
  effect = 'scrollx';

  constructor(
    private _roomHttpService: RoomHttpService) {
    super(_roomHttpService);
  }

  ngOnInit(): void {
    this.gets();
  }

  gets() {

    this.load((p, s) => {
      p = `offset=0&limit=${this.count}`;
      return this._roomHttpService.list(p, s).pipe(
        map((x: any) => {

          x.data.items.forEach(o => {

            o.imageUrl = (o.imageUrl) ? `${environment.serverUri}/${o.imageUrl}` : '';
          });

          return x;
        })
      );
    })
  }
}
