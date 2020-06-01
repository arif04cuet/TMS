import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { environment } from 'src/environments/environment';
import { MethodHttpService } from 'src/services/http/course/method-http.service';

@Component({
  selector: 'app-method-list',
  templateUrl: './method-list.component.html'
})
export class MethodListComponent extends TableComponent {

  @Searchable("Name", "like") name;

  serverUrl = environment.serverUri;

  constructor(
    private methodHttpService: MethodHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(methodHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/courses/methods/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/courses/methods/add');
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
