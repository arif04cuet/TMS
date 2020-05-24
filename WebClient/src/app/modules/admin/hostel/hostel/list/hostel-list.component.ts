import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { environment } from 'src/environments/environment';
import { HostelHttpService } from 'src/services/http/hostel/hostel-http.service';

@Component({
  selector: 'app-hostel-list',
  templateUrl: './hostel-list.component.html'
})
export class HostelListComponent extends TableComponent {

  @Searchable("Name", "like") name;

  serverUrl = environment.serverUri;

  constructor(
    private hostelHttpService: HostelHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(hostelHttpService);
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
