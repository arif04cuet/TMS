import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-exam-home',
  templateUrl: './exam-home.component.html'
})
export class ExamHomeComponent {

  component = 'list';
  model = {};

  constructor(
    private activatedRoute: ActivatedRoute
  ) {

  }

  ngOnInit() {
    const snapshot = this.activatedRoute.snapshot;
  }

  onAction(e) {
    const action = e?.action || '';
    if(e.action == 'cancel') {
      this.component = 'list'
    }
    else if (action == 'add') {
      this.component = 'add';
      this.model = {};
    }
    else if (action == 'edit') {
      this.component = 'add';
      this.model = e.data;
    }
    else if (action == 'result') {
      this.component = 'result';
      this.model = e.data;
    }
    else if (action == 'answer') {
      this.component = 'answer';
      this.model = e.data;
    }
  }

}
