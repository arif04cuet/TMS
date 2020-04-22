import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { forkJoin } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { DepartmentHttpService } from 'src/services/http/department-http.service';

@Component({
  selector: 'app-department-list',
  templateUrl: './department-list.component.html',
  styleUrls: ['./department-list.component.scss']
})
export class DepartmentListComponent extends TableComponent {

  constructor(
    private departmentHttpService: DepartmentHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(departmentHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
    
    this.onDeleted = (res: any) => {
      this.gets();
    }
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/departments/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/departments/add');
    }
  }

  gets(pagination = null, search = null) {
    this.loading = true;
    const request = [
      this.departmentHttpService.list()
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