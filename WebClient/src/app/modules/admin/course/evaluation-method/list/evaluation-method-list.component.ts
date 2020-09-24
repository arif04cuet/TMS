import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { environment } from 'src/environments/environment';
import { EvaluationMethodHttpService } from 'src/services/http/course/evaluation-method-http.service';
import { EvaluationMethodAddComponent } from '../add/evaluation-method-add.component';
import { NzModalService } from 'ng-zorro-antd';

@Component({
  selector: 'app-evaluation-method-list',
  templateUrl: './evaluation-method-list.component.html'
})
export class EvaluationMethodListComponent extends TableComponent {

  @Searchable("Name", "like") name;
  serverUrl = environment.serverUri;

  constructor(
    private evaluationMethodHttpService: EvaluationMethodHttpService,
    private activatedRoute: ActivatedRoute,
    private modalService: NzModalService
  ) {
    super(evaluationMethodHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
  }

  add(model = null) {
    this.addModal(EvaluationMethodAddComponent, this.modalService, {id: model?.id});
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
