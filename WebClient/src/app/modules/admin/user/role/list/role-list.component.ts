import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { forkJoin } from 'rxjs';
import { RoleHttpService } from 'src/services/http/user/role-http.service';
import { ActivatedRoute } from '@angular/router';
import { IButton } from 'src/app/shared/table-actions.component';

@Component({
  selector: 'app-role-list',
  templateUrl: './role-list.component.html'
})
export class RoleListComponent extends TableComponent {

  buttons: IButton[] = [
    {
      label: 'edit',
      action: d => this.add(d),
      permissions: ['role.manage', 'role.update'],
      icon: 'edit'
    },
    {
      label: 'delete',
      action: d => this.delete(d),
      permissions: ['role.manage', 'role.delete'],
      icon: 'delete'
    }
  ]

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

}
