import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { forkJoin } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { OfficeHttpService } from 'src/services/http/user/office-http.service';
import { IButton } from 'src/app/shared/table-actions.component';

@Component({
  selector: 'app-office-list',
  templateUrl: './office-list.component.html'
})
export class OfficeListComponent extends TableComponent {

  @Searchable("OfficeName", "like") name;
  buttons: IButton[] = [
    {
      label: 'edit',
      action: d => this.add(d),
      permissions: ['office.manage', 'office.update'],
      icon: 'edit'
    },
    {
      label: 'delete',
      action: d => this.delete(d),
      permissions: ['office.manage', 'office.delete'],
      icon: 'delete'
    }
  ]

  constructor(
    private activatedRoute: ActivatedRoute,
    private officeHttpService: OfficeHttpService
  ) {
    super(officeHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/offices/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/offices/add');
    }
  }

  gets(pagination = null, search = null) {
    this.loading = true;
    const request = [
      this.officeHttpService.list(pagination, search)
    ]
    this.subscribe(forkJoin(request),
      (res: any) => {
        this.fill(res[0]);
      },
      err => {
        this.loading = false;
      }
    );
  }

  refresh() {
    this.gets(null, this.getSearchTerms());
  }

  search() {
    this.gets(null, this.getSearchTerms())
  }

}
