import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { environment } from 'src/environments/environment';
import { FacilitiesHttpService } from 'src/services/http/hostel/facilities-http.service';

@Component({
  selector: 'app-facilities-list',
  templateUrl: './facilities-list.component.html'
})
export class FacilitiesListComponent extends TableComponent {

  @Searchable("Name", "like") name;

  serverUrl = environment.serverUri;

  constructor(
    private facilitiesHttpService: FacilitiesHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(facilitiesHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/hostels/facilities/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/hostels/facilities/add');
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
