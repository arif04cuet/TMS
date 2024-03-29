import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { environment } from 'src/environments/environment';
import { ExpertiseHttpService } from 'src/services/http/course/expertise-http.service';
import { ExpertiseAddComponent } from '../add/expertise-add.component';
import { NzModalService } from 'ng-zorro-antd';
import { IButton } from 'src/app/shared/table-actions.component';

@Component({
  selector: 'app-expertise-list',
  templateUrl: './expertise-list.component.html'
})
export class ExpertiseListComponent extends TableComponent {

  @Searchable("Name", "like") name;
  serverUrl = environment.serverUri;

  buttons: IButton[] = [
    {
      label: 'edit',
      action: d => this.add(d),
      permissions: ['expertise.manage', 'expertise.update'],
      icon: 'edit'
    },
    {
      label: 'delete',
      action: d => this.delete(d),
      permissions: ['expertise.manage', 'expertise.delete'],
      icon: 'delete'
    }
  ]

  constructor(
    private expertiseHttpService: ExpertiseHttpService,
    private activatedRoute: ActivatedRoute,
    private modalService: NzModalService
  ) {
    super(expertiseHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
  }

  add(model = null) {
    this.addModal(ExpertiseAddComponent, this.modalService, {id: model?.id});
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
