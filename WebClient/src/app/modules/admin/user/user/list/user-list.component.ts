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
    this.goTo('/admin/users/add');
  }

  gets() {
    this.loading = true;
    const request = [
      this.userHttpService.list(),
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
      nzContent: `Do you want to delete ${this.formatUsername(e)}?`,
      nzOkText: 'Delete',
      nzCancelText: 'Cancel',
      nzOkLoading: false,
      nzClosable: false,
      nzOnOk: () => {
        deleteModal.getInstance().nzOkLoading = true;
        this.userHttpService.delete(e.id).subscribe(
          res => {
            deleteModal.getInstance().nzOkLoading = false;
            this.messageService.create('success', `${this.formatUsername(e)} deleted.`);
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
    this.gets();
  }

  private formatUsername(user) {
    let name = ""
    if (user.firstName) {
      name += user.firstName
    }
    if (user.lastName) {
      name += ` ${user.lastName}`
    }
    return name;
  }

}
