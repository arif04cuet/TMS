import { Component } from '@angular/core';
import { UserHttpService } from 'src/services/http/user/user-http.service';
import { TableComponent } from 'src/app/shared/table.component';
import { DesignationHttpService } from 'src/services/http/user/designation-http.service';
import { forkJoin } from 'rxjs';
import { RoleHttpService } from 'src/services/http/user/role-http.service';
import { CommonHttpService } from 'src/services/http/common-http.service';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { environment } from 'src/environments/environment';
import { IButton } from 'src/app/shared/table-actions.component';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html'
})
export class UserListComponent extends TableComponent {

  designations = [];
  roles = [];
  statuses = [];

  @Searchable("FullName", "like") name;
  @Searchable("DesignationId", "eq") designation;
  @Searchable("Mobile", "like") mobile;
  @Searchable("Email", "like") email;
  serverUrl = environment.serverUri;
  buttons: IButton[] = [
    {
      label: 'edit',
      action: d => this.add(d),
      permissions: ['user.manage', 'user.update'],
      icon: 'edit'
    },
    {
      label: 'delete',
      action: d => this.delete(d),
      permissions: ['user.manage', 'user.delete'],
      icon: 'delete'
    }
  ]

  constructor(
    private userHttpService: UserHttpService,
    private designationHttpService: DesignationHttpService,
    private commonHttpService: CommonHttpService,
    private roleHttpService: RoleHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(userHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/users/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/users/add');
    }
  }

  gets() {
    this.loading = true;
    this.load();
    const request = [
      this.designationHttpService.list(),
      this.roleHttpService.list(),
      this.commonHttpService.getStatusList()
    ]
    this.subscribe(forkJoin(request),
      (res: any) => {
        this.loading = false;
        this.designations = res[0].data.items;
        this.roles = res[1].data.items;
        this.statuses = res[2].data.items;
      },
      err => {
        this.loading = false;
      }
    );
  }

  refresh() {
    this.load();
  }

  search() {
    this.load();
  }

}
