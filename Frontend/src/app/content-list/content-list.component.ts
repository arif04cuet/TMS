import { Component, ViewChild, Input } from '@angular/core';
import { CmsHttpService } from 'src/services/cms-http-service';
import { TableComponent } from 'src/shared/table.component';
import { of } from 'rxjs';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-content-list',
  templateUrl: './content-list.component.html',
  styleUrls: ['./content-list.component.css']
})
export class ContentListComponent extends TableComponent {

 @Input() category:string = "News";
 @Input() showTitle:boolean = false;
 @Input() bodyCharacters:number = 300;
 
  constructor(
    private cmsHttpService: CmsHttpService,
    private activatedRoute: ActivatedRoute) {
    super(cmsHttpService);
  }

  ngOnInit(): void {
    //this.gets();
  }

  ngAfterViewInit() {
    const snapshot = this.activatedRoute.snapshot
    this.category = snapshot.params.category ? snapshot.params.category : this.category;
    this.gets(this.category);
  }

  gets(categoryName =null) {

    
    this.load((p, s) => {
      
      var s = `Search=Category.Name like ${categoryName}`;
      return this.cmsHttpService.contents(p,s).pipe(
      map((x:any)=>{
        
        x.data.items.forEach(o => {
          o.imageUrl = (o.imageUrl) ? `${environment.serverUri}/${o.imageUrl}`:'https://via.placeholder.com/100';
          o.body = o.body?o.body.substring(0,this.bodyCharacters)+'...':'';
        });
        
        return x;
      })
    );
    });

  }

  view(item) {
    if (item) {
      this.goTo(`/contents/${item.category.name}/${item.id}`);
    }
  }
 

}
