import { Component } from '@angular/core';
import { BaseComponent } from 'src/app/shared/base.component';
import { ActivatedRoute } from '@angular/router';
import { environment } from 'src/environments/environment';
import { MyExamHttpService } from 'src/services/http/budget-and-schedule/my-exam-http.service';
import { FormComponent } from 'src/app/shared/form.component';

@Component({
  selector: 'app-my-exam-start',
  templateUrl: './my-exam-start.component.html'
})
export class MyExamStartComponent extends FormComponent {

  loading: boolean = false;
  data: any = {}
  serverUrl = environment.serverUri;
  timeRemaining = ''
  totalTime = ''

  private examId;

  constructor(
    private myExamHttpService: MyExamHttpService,
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
    this.subscribe(this.myExamHttpService.get(id),
      (res: any) => {
        this.data = res.data;
        this.data.totalSeconds = this.data.totalMinutes * 60;
        this.totalTime = this.getTimeString(this.data.totalSeconds);
        this.loading = false;
        setInterval(() => {
          --this.data.totalSeconds;
          setTimeout(() => {
            this.timeRemaining = this.getTimeString(this.data.totalSeconds);
          });
        }, 1000);
      },
      (err: any) => {
        this.loading = false;
      }
    );
  }

  start() {
    this.goTo(`/admin/profile/edit`)
  }

  cancel() {
    this.goTo(`/admin/trainings/my-exam`);
  }

  submit() {
    if (!this.data && !this.data.questions) {
      this.failed('failed');
      return;
    }
    const body = {
      examId: this.id,
      answers: this.data.questions.map(x => {
        return {
          question: x.id,
          mcqAnswer: x.mcqAnswer,
          WrittenAnswer: x.writtenAnswer
        }
      })
    };
    this.log(body);
    return;
    this.loading = true;
    this.subscribe(this.myExamHttpService.add(body),
    (res: any) => {
      this.loading = false;
      this.success('success');
    },
    err => {
      this.loading = false;
      this.failed('failed');
    }
    );
  }

  getTimeString(seconds: number) {
    var h = Math.floor(seconds / 3600);
    var m = Math.floor(seconds % 3600 / 60);
    var s = Math.floor(seconds % 3600 % 60);
    return `${h}:${m}:${s}`;
  }

}
