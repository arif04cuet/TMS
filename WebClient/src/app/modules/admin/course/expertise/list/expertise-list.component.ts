import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { environment } from 'src/environments/environment';
import { ExpertiseHttpService } from 'src/services/http/course/expertise-http.service';

@Component({
  selector: 'app-expertise-list',
  templateUrl: './expertise-list.component.html'
})
export class ExpertiseListComponent extends TableComponent {

  @Searchable("Name", "like") name;

  serverUrl = environment.serverUri;

  constructor(
    private expertiseHttpService: ExpertiseHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(expertiseHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/courses/expertise/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/courses/expertise/add');
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
