import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { environment } from 'src/environments/environment';
import { AllocationHttpService } from 'src/services/http/hostel/allocation-http.service';

@Component({
  selector: 'app-allocation-list',
  templateUrl: './allocation-list.component.html'
})
export class AllocationListComponent extends TableComponent {

  @Searchable("Name", "like") name;
  @Searchable("Hostel.Name", "like") hostel;

  serverUrl = environment.serverUri;

  constructor(
    private allocationHttpService: AllocationHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(allocationHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/hostels/allocations/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/hostels/allocations/add');
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
