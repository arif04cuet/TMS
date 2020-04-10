import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { forkJoin } from 'rxjs';
import { DesignationHttpService } from 'src/services/http/designation-http.service';

@Component({
  selector: 'app-designation-list',
  templateUrl: './designation-list.component.html',
  styleUrls: ['./designation-list.component.scss']
})
export class DesignationListComponent extends TableComponent {

  constructor(
    private designationHttpService: DesignationHttpService
  ) {
    super(designationHttpService);
  }

  ngOnInit() {
    this.gets();
    
    this.onDeleted = (res: any) => {
      this.gets();
    }
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/designations/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/designations/add');
    }
  }

  gets(pagination = null, search = null) {
    this.loading = true;
    const request = [
      this.designationHttpService.list()
    ]
    this.subscribe(forkJoin(request),
      (res: any) => {
        this.fill(res[0]);
      },
      err => {
        console.log(err);
        this.loading = false;
      }
    );
  }

  refresh() {
    this.gets(null, null);
  }

}
