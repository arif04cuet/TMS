import { Component, Input } from '@angular/core';
import {CmsHttpService} from '../../services/cms-http-service';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { TableComponent } from 'src/shared/table.component';


@Component({
  selector: 'app-faq',
  templateUrl: './faq.component.html',
  styleUrls: ['./faq.component.css']
})
export class FaqComponent extends TableComponent  {

  constructor(
    private _cmsHttpService: CmsHttpService) {
   super(_cmsHttpService);
  }

  ngOnInit(): void {
    this.gets();
  }

  gets() {
    
    this.load((p, s) => {
      
      return this._cmsHttpService.faq(p,s).pipe(
        map((x:any)=>{
          
          x.data.items.forEach(o => {
            
            //o.mediaUrl = (o.mediaUrl) ? `${environment.serverUri}/${o.mediaUrl}`:'';
          });
          
          return x;
        })
      );
    })
  }
}
