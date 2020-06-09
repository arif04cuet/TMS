import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TableComponent } from 'src/app/shared/table.component';
import { NzModalService } from 'ng-zorro-antd';
import { Searchable } from 'src/decorators/searchable.decorator';
import { EvaluationMethodHttpService } from 'src/services/http/course/evaluation-method-http.service';

@Component({
  selector: 'app-evaluation-method-modal',
  templateUrl: './evaluation-method-modal.component.html'
})
export class EvaluationMethodModalComponent extends TableComponent {

  selectedItem;
  @Searchable("Name", "like") name;

  constructor(
    private evaluationMethodHttpService: EvaluationMethodHttpService,
    private activatedRoute: ActivatedRoute,
    private modal: NzModalService
  ) {
    super(evaluationMethodHttpService);
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
      let search;
      if(this.name) {
        search += `&Search=Name like ${this.name}`;
      }
      return this.evaluationMethodHttpService.list(p, search);
    });
  }

  select(e) {
    this.selectedItem = e;
    this.modal.closeAll();
  }

}
