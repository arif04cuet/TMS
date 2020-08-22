import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { RequisitionHttpService } from 'src/services/http/asset/requisition-http.service';

@Component({
  selector: 'app-requisition-list',
  templateUrl: './requisition-list.component.html'
})
export class RequisitionListComponent extends TableComponent {

  @Searchable("Title", "like") title;
  @Searchable("Status", "like") status;

  constructor(
    private requisitionHttpService: RequisitionHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(requisitionHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.load();

    this.onDeleted = (res: any) => {
      this.load();
    }
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/asset/my-requisitions/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/asset/my-requisitions/add');
    }
  }

  search() {
    this.load();
  }

  refresh() {
    this.load();
  }

  view(model) {
    if(model) {
      this.goTo(`/admin/asset/my-requisitions/${model.id}/view`);
    }
  }

  approve(model) {

  }

  reject(model) {
    
  }

}
