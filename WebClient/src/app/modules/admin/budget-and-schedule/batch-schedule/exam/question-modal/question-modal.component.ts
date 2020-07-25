import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TableComponent } from 'src/app/shared/table.component';
import { NzModalService } from 'ng-zorro-antd';
import { QuestionHttpService } from 'src/services/http/budget-and-schedule/question-http.service';

@Component({
  selector: 'app-question-modal',
  templateUrl: './question-modal.component.html'
})
export class QuestionModalComponent extends TableComponent {

  selectedItem;

  constructor(
    private questionHttpService: QuestionHttpService,
    private activatedRoute: ActivatedRoute,
    private modal: NzModalService
  ) {
    super(questionHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
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
      return this.questionHttpService.list(p, s);
    });
  }

  select(e) {
    this.selectedItem = e;
    this.log('selected question', e);
    this.close();
  }

  close() {
    this.modal.closeAll();
  }

}
