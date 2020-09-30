import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { environment } from 'src/environments/environment';
import { EvaluationMethodHttpService } from 'src/services/http/course/evaluation-method-http.service';
import { EvaluationMethodAddComponent } from '../add/evaluation-method-add.component';
import { NzModalService } from 'ng-zorro-antd';
import { IButton } from 'src/app/shared/table-actions.component';

@Component({
  selector: 'app-evaluation-method-list',
  templateUrl: './evaluation-method-list.component.html'
})
export class EvaluationMethodListComponent extends TableComponent {

  @Searchable("Name", "like") name;
  serverUrl = environment.serverUri;

  buttons: IButton[] = [
    {
      label: 'edit',
      action: d => this.add(d),
      permissions: ['evaluation.method.manage', 'evaluation.method.update'],
      icon: 'edit'
    },
    {
      label: 'delete',
      action: d => this.delete(d),
      permissions: ['evaluation.method.manage', 'evaluation.method.delete'],
      icon: 'delete'
    }
  ]

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
