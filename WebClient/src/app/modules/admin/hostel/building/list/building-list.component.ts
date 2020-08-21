import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { environment } from 'src/environments/environment';
import { BuildingHttpService } from 'src/services/http/hostel/building-http.service';
import { HostelHttpService } from 'src/services/http/hostel/hostel-http.service';

@Component({
  selector: 'app-building-list',
  templateUrl: './building-list.component.html'
})
export class BuildingListComponent extends TableComponent {

  @Searchable("Name", "like") name;
  //@Searchable("Hostel.Name", "like") hostel;
  @Searchable("HostelId", "eq") hostels;

  serverUrl = environment.serverUri;

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
  }

  refresh() {
    this.load();
    this.subscribe(this.hostelHttpService.list(),
    (res: any) => {
      this.hostels = res.data.items;
    },
    err => {
      console.log(err);
      this.loading = false;
    }
  );
  }

  search() {
    this.load();
  }

}
