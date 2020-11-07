import { Component, ViewChild } from '@angular/core';
import { TrainingCourseHttpService } from 'src/services/training-course-http-service';
import { ActivatedRoute } from '@angular/router';
import { FormComponent } from 'src/shared/form.component';
import { SelectControlComponent } from 'src/shared/select-control/select-control.component';
import { AuthService } from 'src/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-training-course-apply',
  templateUrl: './training-course-apply.component.html',
  styleUrls: ['./training-course-apply.component.css']
})
export class TrainingCourseApplyComponent extends FormComponent {

  looggedInUser = null;
  item = null;
  allocation = null;
  alreadyApplied = false;
  firstAvailableBed;

  @ViewChild('bedSelect') bedSelect: SelectControlComponent;

  constructor(
    private trainingCourseHttpService: TrainingCourseHttpService,
    private authService: AuthService,
    private router: Router,
    private activatedRoute: ActivatedRoute) {
    super();
  }

  ngOnInit(): void {


    const snapshot = this.activatedRoute.snapshot
    const id = snapshot.params.id;

    if (!this.authService.isAuthenticated()) {
      this.goTo(`/course`);
    }
    this.batchAllocation(id);
    this.looggedInUser = this.authService.getLoggedInUserInfo();
    this.get(id);

    this.createForm({
      bed: []
    });
    this.markModeAsAdd();
  }

  ngAfterViewInit() {
    // this.bedSelect.register((pagination, search) => {
    //   return this.trainingCourseHttpService.beds(pagination, search);
    // }).fetch();
  }

  navigate(route: string) {
    this.router.navigateByUrl(route)
  }

  get(id) {
    this.subscribe(this.trainingCourseHttpService.get(id),
      (res: any) => {
        this.item = res.data;

      },
      err => { }
    );

    this.getBeds();
  }

  getBeds() {

    this.subscribe(this.trainingCourseHttpService.beds(),
      (res: any) => {

        this.firstAvailableBed = res.data.items[0];

      },
      err => { }
    );


  }
  batchAllocation(id) {
    this.subscribe(this.trainingCourseHttpService.batchAllocation(id),
      (res: any) => {

        this.allocation = res.data.items ? res.data.items[0] : null;
        this.alreadyApplied = this.allocation?.trainee?.id == this.looggedInUser?.id;
      },
      err => { }
    );
  }


  apply() {
    const body: any = this.constructObject(this.form.controls);
    //this.looggedInUser = this.authService.getLoggedInUserInfo();
    body['trainee'] = this.looggedInUser.id;
    body['batchSchedule'] = this.item.id;
    body['course'] = this.item.course.id;
    body['appliedDate'] = new Date().toJSON("yyyy/MM/dd HH:mm");
    body['status'] = 3;
    body['bed'] = this.firstAvailableBed.id;


    this.submitForm(
      {

        request: this.trainingCourseHttpService.apply(this.item.id, body),
        succeed: res => {
          const msg = this._translate.instant('successfully_applied');

          this.success(msg);
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
