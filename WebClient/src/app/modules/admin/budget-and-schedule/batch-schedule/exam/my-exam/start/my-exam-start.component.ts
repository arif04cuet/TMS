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

  constructor(
    private myExamHttpService: MyExamHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super();
  }

  ngOnInit() {
    const snapshot = this.activatedRoute.snapshot;
    const examId = snapshot.params.id;
    this.get(examId);
  }

  get(id) {
    this.subscribe(this.myExamHttpService.get(id),
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
    this.goTo(`/admin/profile/edit`)
  }

  cancel() {
    this.goTo(`/admin/trainings/my-exam`);
  }

  submit() {

  }

}
