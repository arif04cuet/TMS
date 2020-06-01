import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { environment } from 'src/environments/environment';
import { GradeHttpService } from 'src/services/http/course/grades-http.service';

@Component({
  selector: 'app-grade-list',
  templateUrl: './grade-list.component.html'
})
export class GradeListComponent extends TableComponent {

  @Searchable("Name", "like") name;

  serverUrl = environment.serverUri;

  constructor(
    private gradeHttpService: GradeHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(gradeHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/courses/grades/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/courses/grades/add');
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
