import { Component, ViewChild } from '@angular/core';
import { TrainingCourseHttpService } from 'src/services/training-course-http-service';
import { ActivatedRoute } from '@angular/router';
import { FormComponent } from 'src/shared/form.component';
import { SelectControlComponent } from 'src/shared/select-control/select-control.component';

@Component({
  selector: 'app-training-course-apply',
  templateUrl: './training-course-apply.component.html',
  styleUrls: ['./training-course-apply.component.css']
})
export class TrainingCourseApplyComponent extends FormComponent {

  item = null;
  @ViewChild('bedSelect') bedSelect: SelectControlComponent;

  constructor(
    private trainingCourseHttpService: TrainingCourseHttpService,
    private activatedRoute: ActivatedRoute) {
    super();
  }

  ngOnInit(): void {
    const snapshot = this.activatedRoute.snapshot
    const id = snapshot.params.id;
    this.get(id);
    this.createForm({
      bed: []
    });
    this.markModeAsAdd();
  }

  ngAfterViewInit() {
    this.bedSelect.register((pagination, search) => {
      return this.trainingCourseHttpService.beds(pagination, search);
    }).fetch();
  }

  get(id) {
    this.subscribe(this.trainingCourseHttpService.get(id),
      (res: any) => {
        this.item = res.data;
      },
      err => { }
    );
  }

  apply() {
    const body: any = this.constructObject(this.form.controls);
    this.submitForm(
      {
        request: this.trainingCourseHttpService.apply(this.item.id, body),
        succeed: res => {
          this.success('Success');
          this.goTo('/course');
        },
        failed: err => {
          this.log(err);
        }
      },
      null
    );
  }

}
