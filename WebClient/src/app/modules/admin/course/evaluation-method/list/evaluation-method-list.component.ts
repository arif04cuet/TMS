import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { environment } from 'src/environments/environment';
import { EvaluationMethodHttpService } from 'src/services/http/course/evaluation-method-http.service';

@Component({
  selector: 'app-evaluation-method-list',
  templateUrl: './evaluation-method-list.component.html'
})
export class EvaluationMethodListComponent extends TableComponent {

  @Searchable("Name", "like") name;

  serverUrl = environment.serverUri;

  constructor(
    private evaluationMethodHttpService: EvaluationMethodHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(evaluationMethodHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/courses/evaluation-methods/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/courses/evaluation-methods/add');
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
