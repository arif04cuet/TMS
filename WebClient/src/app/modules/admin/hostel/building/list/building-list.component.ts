import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { environment } from 'src/environments/environment';
import { BuildingHttpService } from 'src/services/http/hostel/building-http.service';
import { HostelHttpService } from 'src/services/http/hostel/hostel-http.service';
import { IButton } from 'src/app/shared/table-actions.component';

@Component({
  selector: 'app-building-list',
  templateUrl: './building-list.component.html'
})
export class BuildingListComponent extends TableComponent {

  hostels = [];
  @Searchable("Name", "like") name;
  @Searchable("HostelId", "eq") hostel;
  serverUrl = environment.serverUri;

  buttons: IButton[] = [
    {
      label: 'edit',
      action: d => this.add(d),
      permissions: ['building.manage', 'building.update'],
      icon: 'edit'
    },
    {
      label: 'delete',
      action: d => this.delete(d),
      permissions: ['building.manage', 'building.delete'],
      icon: 'delete'
    }
  ]

  constructor(
    private hostelHttpService: HostelHttpService,
    private buildingHttpService: BuildingHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(buildingHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/hostels/buildings/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/hostels/buildings/add');
    }
  }

  gets() {
    this.load();
    this.subscribe(this.hostelHttpService.list(),
      (res: any) => {
        res.data.items.forEach(e => {
          this.hostels.push({ id: e.id, name: e.name });
        });
      },
      err => {
        console.log(err);
        this.loading = false;
      }
    );
  }

  refresh() {
    this.load();

  }

  search() {
    this.load();
  }

}
