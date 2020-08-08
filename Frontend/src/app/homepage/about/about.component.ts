import { Component } from '@angular/core';
import { CmsHttpService } from 'src/services/cms-http-service';
import { TableComponent } from 'src/shared/table.component';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.css']
})
export class AboutComponent extends TableComponent {

 
  constructor(
    private cmsHttpService: CmsHttpService) {
    super(cmsHttpService);
  }

  ngOnInit(): void {
    //this.gets();
  }

  ngAfterViewInit() {
   
  }
  viewcategory(category)
  {
    this.goTo(`/contents/${category}`);
  }


}
