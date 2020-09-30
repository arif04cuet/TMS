import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { RequisitionHttpService } from 'src/services/http/asset/requisition-http.service';
import { map } from 'rxjs/operators';
import { IButton } from 'src/app/shared/table-actions.component';

@Component({
  selector: 'app-requisition-list',
  templateUrl: './requisition-list.component.html'
})
export class RequisitionListComponent extends TableComponent {

  @Searchable("Title", "like") title;
  @Searchable("Status", "eq") status;
  isInventoryManager = false;
  statuses = [
    { id: 1, name: 'Initiated' },
    { id: 2, name: 'TemporaryApproved' },
    { id: 3, name: 'Approved' },
    { id: 4, name: 'Rejected' },
  ];
  buttons: IButton[] = [
    { 
      label: 'reject',
      action: d => this.reject(d),
      condition: d => d.canReject
    },
    {
      label: 'approve',
      action: d => this.approve(d),
      condition: d => d.canApprove || (d.canApprove && d.canTemporaryApprove)
    },
    {
      label: 'temporary.approve',
      action: d => this.approve(d),
      condition: d => d.canTemporaryApprove && !d.canApprove
    },
    {
      label: 'view',
      action: d => this.view(d),
      permissions: ['requisition.manage', 'requisition.view'],
      icon: 'eye'
    },
    {
      label: 'edit',
      action: d => this.add(d),
      permissions: ['requisition.manage', 'requisition.update'],
      icon: 'edit'
    },
    {
      label: 'delete',
      action: d => this.delete(d),
      permissions: ['requisition.manage', 'requisition.delete'],
      icon: 'delete'
    }
  ]

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

  load() {
    super.load((p, s) => {
      return this.requisitionHttpService.list(s, p).pipe(
        map((x: any) => {
          if (x.data.items && x.data.items.length > 0) {
            this.isInventoryManager = x.data.items[0].isInventoryManager;
          }
          return x;
        })
      );
    });
  }

  view(model) {
    if (model) {
      this.goTo(`/admin/asset/my-requisitions/${model.id}/view`);
    }
  }

  approve(model) {
    this.view(model);
  }

  reject(model) {
    this.view(model);
  }

}
