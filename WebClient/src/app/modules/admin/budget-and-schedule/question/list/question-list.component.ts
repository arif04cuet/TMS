import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { environment } from 'src/environments/environment';
import { QuestionHttpService } from 'src/services/http/budget-and-schedule/question-http.service';
import { IButton } from 'src/app/shared/table-actions.component';

@Component({
  selector: 'app-question-list',
  templateUrl: './question-list.component.html'
})
export class QuestionListComponent extends TableComponent {

  @Searchable("Name", "like") name;
  serverUrl = environment.serverUri;

  buttons: IButton[] = [
    {
      label: 'edit',
      action: d => this.add(d),
      permissions: ['question.manage', 'question.update'],
      icon: 'edit'
    },
    {
      label: 'delete',
      action: d => this.delete(d),
      permissions: ['question.manage', 'question.delete'],
      icon: 'delete'
    }
  ]

  constructor(
    private questionHttpService: QuestionHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(questionHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/trainings/questions/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/trainings/questions/add');
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
