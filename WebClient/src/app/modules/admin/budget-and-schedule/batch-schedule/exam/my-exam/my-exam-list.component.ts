import { Component, Output, EventEmitter } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { MyExamHttpService } from 'src/services/http/budget-and-schedule/my-exam-http.service';

@Component({
  selector: 'app-my-exam-list',
  templateUrl: './my-exam-list.component.html'
})
export class MyExamListComponent extends TableComponent {

  @Output() onAction = new EventEmitter();

  constructor(
    private myExamHttpService: MyExamHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(myExamHttpService);
  }

  ngOnInit() {
    const snapshot = this.activatedRoute.snapshot;
    this.gets();
  }

  add(model = null) {
    if (model) {
      this.onAction.emit({
        action: 'edit',
        data: model
      });
    }
    else {
      this.onAction.emit({
        action: 'add'
      });
    }
  }

  view(e) {
    this.goTo(`/admin/trainings/my-exam/${e.id}/view`);
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

  load() {
    super.load((p, s) => {
      return this.myExamHttpService.list(p, s);
    });
  }

}
