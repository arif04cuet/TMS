import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { forkJoin } from 'rxjs';
import { DesignationHttpService } from 'src/services/http/user/designation-http.service';
import { ActivatedRoute } from '@angular/router';
import { DesignationAddComponent } from '../add/designation-add.component';
import { NzModalService } from 'ng-zorro-antd';

@Component({
  selector: 'app-designation-list',
  templateUrl: './designation-list.component.html'
})
export class DesignationListComponent extends TableComponent {

  constructor(
    private designationHttpService: DesignationHttpService,
    private activatedRoute: ActivatedRoute,
    private modalService: NzModalService
  ) {
    super(designationHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
    this.onDeleted = (res: any) => {
      this.gets();
    }
  }

  add(model = null) {
    this.addModal(DesignationAddComponent, this.modalService, {id: model?.id});
    // if (model) {
    //   this.goTo(`/admin/designations/${model.id}/edit`);
    // }
    // else {
    //   this.goTo('/admin/designations/add');
    // }
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
