import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { environment } from 'src/environments/environment';
import { FacilitiesHttpService } from 'src/services/http/hostel/facilities-http.service';
import { FacilitiesAddComponent } from '../add/facilities-add.component';
import { NzModalService } from 'ng-zorro-antd';
import { IButton } from 'src/app/shared/table-actions.component';

@Component({
  selector: 'app-facilities-list',
  templateUrl: './facilities-list.component.html'
})
export class FacilitiesListComponent extends TableComponent {

  @Searchable("Name", "like") name;
  serverUrl = environment.serverUri;

  buttons: IButton[] = [
    {
      label: 'edit',
      action: d => this.add(d),
      permissions: ['room.facilities.manage', 'room.facilities.update'],
      icon: 'edit'
    },
    {
      label: 'delete',
      action: d => this.delete(d),
      permissions: ['room.facilities.manage', 'room.facilities.delete'],
      icon: 'delete'
    }
  ]

  constructor(
    private facilitiesHttpService: FacilitiesHttpService,
    private activatedRoute: ActivatedRoute,
    private modalService: NzModalService
  ) {
    super(facilitiesHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
  }

  add(model = null) {
    this.addModal(FacilitiesAddComponent, this.modalService, {id: model?.id});
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
