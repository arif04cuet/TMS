import { Component, Input } from '@angular/core';
import {CmsHttpService} from '../../services/cms-http-service';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { TableComponent } from 'src/shared/table.component';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-page',
  templateUrl: './page.component.html',
  styleUrls: ['./page.component.css']
})
export class PageComponent extends TableComponent  {

  @Input() slug:string;

  item = null;

  constructor(
    private _cmsHttpService: CmsHttpService,
    private activatedRoute: ActivatedRoute
    ) {
   super(_cmsHttpService);
  }

  ngOnInit(): void {
    const snapshot = this.activatedRoute.params.subscribe(x=>{
      console.log(x);
      this.get(x.slug);
    });
  }

  get(slug) {
    
      var p = ``;
      var s = `Search=Slug eq ${slug}&Search=Category.Name like Page&limit=1`;
      var items = this._cmsHttpService.contents(p,s).pipe(
        map((x:any)=>{
          
          x.data.items.forEach(o => {
            
            //o.mediaUrl = (o.mediaUrl) ? `${environment.serverUri}/${o.mediaUrl}`:'';
          });
          
          return x;
        })
      );

      this.subscribe(items,res=>{
        this.item = res.data.items[0];
        
      });
      
    
  }
}
