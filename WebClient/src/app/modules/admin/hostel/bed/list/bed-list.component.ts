import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { environment } from 'src/environments/environment';
import { BedHttpService } from 'src/services/http/hostel/bed-http.service';

@Component({
  selector: 'app-bed-list',
  templateUrl: './bed-list.component.html'
})
export class BedListComponent extends TableComponent {

  @Searchable("Name", "like") name;

  serverUrl = environment.serverUri;

  constructor(
    private bedHttpService: BedHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(bedHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/hostels/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/hostels/add');
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
