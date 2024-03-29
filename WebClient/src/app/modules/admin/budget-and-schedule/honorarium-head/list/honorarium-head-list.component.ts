import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { environment } from 'src/environments/environment';
import { HonorariumHeadHttpService } from 'src/services/http/budget-and-schedule/honorarium-head-http.service';
import { IButton } from 'src/app/shared/table-actions.component';

@Component({
  selector: 'app-honorarium-head-list',
  templateUrl: './honorarium-head-list.component.html'
})
export class HonorariumHeadListComponent extends TableComponent {

  @Searchable("Name", "like") name;
  serverUrl = environment.serverUri;

  buttons: IButton[] = [
    {
      label: 'edit',
      action: d => this.add(d),
      permissions: ['honorarium.head.manage', 'honorarium.head.update'],
      icon: 'edit'
    },
    {
      label: 'delete',
      action: d => this.delete(d),
      permissions: ['honorarium.head.manage', 'honorarium.head.delete'],
      icon: 'delete'
    }
  ]

  constructor(
    private honorariumHeadHttpService: HonorariumHeadHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(honorariumHeadHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/trainings/honorarium-heads/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/trainings/honorarium-heads/add');
    }
  }

  gets() {
    this.load();
  }

  refresh() {
    this.load();
  }

  search() {
    this.load();
  }

}
