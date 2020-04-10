import { Component } from '@angular/core';
import { NzModalService, NzModalRef, NzMessageService } from 'ng-zorro-antd';
import { UserHttpService } from 'src/services/http/user-http.service';
import { TableComponent } from 'src/app/shared/table.component';
import { DesignationHttpService } from 'src/services/http/designation-http.service';
import { forkJoin } from 'rxjs';
import { RoleHttpService } from 'src/services/http/role-http.service';
import { CommonHttpService } from 'src/services/http/common-http.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent extends TableComponent {

  designations = [];
  roles = [];
  statuses = [];

  name;
  designation;
  mobile;
  email;

  constructor(
    private modalService: NzModalService,
    private messageService: NzMessageService,
    private userHttpService: UserHttpService,
    private designationHttpService: DesignationHttpService,
    private commonHttpService: CommonHttpService,
    private roleHttpService: RoleHttpService
  ) {
    super();
  }

  ngOnInit() {
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

  gets(pagination = null, search = null) {
    this.loading = true;
    const request = [
      this.userHttpService.list(pagination, search),
      this.designationHttpService.list(),
      this.roleHttpService.list(),
      this.commonHttpService.getStatusList()
    ]
    this.subscribe(forkJoin(request),
      (res: any) => {
        this.fill(res[0]);
        this.designations = res[1].data.items;
        this.roles = res[2].data.items;
        this.statuses = res[3].data.items;
      },
      err => {
        console.log(err);
        this.loading = false;
      }
    );
  }

  delete(e) {
    const deleteModal = this.modalService.confirm({
      nzTitle: 'Confirm',
      nzContent: `Do you want to delete?`,
      nzOkText: 'Delete',
      nzCancelText: 'Cancel',
      nzOkLoading: false,
      nzClosable: false,
      nzOnOk: () => {
        deleteModal.getInstance().nzOkLoading = true;
        this.userHttpService.delete(e.id).subscribe(
          res => {
            deleteModal.getInstance().nzOkLoading = false;
            this.messageService.create('success', `Deleted.`);
            this.gets();
          },
          err => {
            deleteModal.getInstance().nzOkLoading = false;
            console.log('err', err)
          }
        );
      }
    });
  }

  refresh() {
    this.gets(null, this.getSearchTerm());
  }

  search() {
    this.gets(null, this.getSearchTerm())
  }

  private getSearchTerm() {
    let search = ""
    if (this.name) {
      search += `Search=FullName like ${this.name}&`;
    }
    if(this.email) {
      search += `Search=Email like ${this.email}&`;
    }
    if(this.designation) {
      search += `Search=DesignationId eq ${this.designation}&`;
    }
    if(this.mobile) {
      search += `Search=Mobile like ${this.mobile}&`;
    }
    return search;
  }

}
