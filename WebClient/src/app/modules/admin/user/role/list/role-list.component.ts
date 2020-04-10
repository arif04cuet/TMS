import { Component } from '@angular/core';
import { NzModalService, NzMessageService } from 'ng-zorro-antd';
import { TableComponent } from 'src/app/shared/table.component';
import { forkJoin } from 'rxjs';
import { RoleHttpService } from 'src/services/http/role-http.service';

@Component({
  selector: 'app-role-list',
  templateUrl: './role-list.component.html',
  styleUrls: ['./role-list.component.scss']
})
export class RoleListComponent extends TableComponent {

  constructor(
    private modalService: NzModalService,
    private messageService: NzMessageService,
    private roleHttpService: RoleHttpService
  ) {
    super();
  }

  ngOnInit() {
    this.gets();
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
        this.roleHttpService.delete(e.id).subscribe(
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
    this.gets(null, null);
  }

}
