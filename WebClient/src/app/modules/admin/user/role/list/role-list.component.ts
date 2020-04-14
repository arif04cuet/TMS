import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { forkJoin } from 'rxjs';
import { RoleHttpService } from 'src/services/http/role-http.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-role-list',
  templateUrl: './role-list.component.html',
  styleUrls: ['./role-list.component.scss']
})
export class RoleListComponent extends TableComponent {

  constructor(
    private roleHttpService: RoleHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(roleHttpService);
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
      this.goTo(`/admin/roles/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/roles/add');
    }
  }

  gets(pagination = null, search = null) {
    this.loading = true;
    const request = [
      this.roleHttpService.list()
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

  assignPermission(data) {
    this.goTo(`/admin/roles/${data.id}/permissions`)
  }

}
