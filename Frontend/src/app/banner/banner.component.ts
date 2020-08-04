import { Component, Input } from '@angular/core';
import {CmsHttpService} from '../../services/cms-http-service';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { TableComponent } from 'src/shared/table.component';

@Component({
  selector: 'app-banner',
  templateUrl: './banner.component.html',
  styleUrls: ['./banner.component.css']
})
export class BannerComponent extends TableComponent  {

  @Input() count:number = 3;
  effect = 'scrollx';

  constructor(
    private _cmsHttpService: CmsHttpService) {
   super(_cmsHttpService);
  }

  ngOnInit(): void {
    this.gets();
  }

  gets() {
    
    this.load((p, s) => {
      p = `offset=0&limit=${this.count}`;
      return this._cmsHttpService.list(p,s).pipe(
        map((x:any)=>{
          
          x.data.items.forEach(o => {
            
            o.mediaUrl = (o.mediaUrl) ? `${environment.serverUri}/${o.mediaUrl}`:'';
          });
          
          return x;
        })
      );
    })
  }
}
