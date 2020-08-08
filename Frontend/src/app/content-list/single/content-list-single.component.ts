import { TableComponent } from 'src/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { CmsHttpService } from 'src/services/cms-http-service';
import { Component } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
    selector:'app-content-single',
    templateUrl:'./content-list-single.html',
    styleUrls:['./content-list-single.css']
})
export class ContentListSingleComponent extends TableComponent{

    item=null;

    constructor(
        private cmsHttpService : CmsHttpService,
        private activatedRoute: ActivatedRoute
    ){
        super(cmsHttpService);
    }

    ngOnInit(): void {
        const snapshot = this.activatedRoute.snapshot
        const id = snapshot.params.id;
        this.get(id);
    }

    get(id) {
        
        this.subscribe(this.cmsHttpService.get(id),
          (res: any) => {
            this.item = res.data;
            this.item.attachmentUrl = (this.item.attachmentUrl)?`${environment.serverUri}/${this.item.attachmentUrl}`:'';
            this.item.imageUrl = (this.item.imageUrl)?`${environment.serverUri}/${this.item.imageUrl}`:'';
          },
          err => { }
        );
      }


    onBack(item): void {

        this.goTo(`/contents/${item.category.name}`);
           
      }


}