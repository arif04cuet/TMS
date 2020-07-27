import { Component } from '@angular/core';
import { BaseComponent } from 'src/app/shared/base.component';
import { ActivatedRoute } from '@angular/router';
import { environment } from 'src/environments/environment';
import { ExamHttpService } from 'src/services/http/budget-and-schedule/exam-http.service';

@Component({
  selector: 'app-my-exam-view',
  templateUrl: './my-exam-view.component.html',
  styleUrls: ['./my-exam-view.component.scss']
})
export class MyExamViewComponent extends BaseComponent {

  loading: boolean = false;
  data: any = {}
  serverUrl = environment.serverUri;

  private examId;

  constructor(
    private examHttpService: ExamHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super();
  }

  ngOnInit() {
    const snapshot = this.activatedRoute.snapshot;
    this.examId = snapshot.params.id;
    this.get(this.examId);
  }

  get(id) {
    this.subscribe(this.examHttpService.get(id),
      (res: any) => {
        this.data = res.data;
        this.loading = false;
      },
      (err: any) => {
        this.loading = false;
      }
    );
  }

  start() {
    this.goTo(`/admin/trainings/my-exam/${this.examId}/start`);
  }

  cancel() {
    this.goTo(`/admin/trainings/my-exam`);
  }

}
