import { Component } from '@angular/core';
import { TrainingCourseHttpService } from 'src/services/training-course-http-service';
import { ActivatedRoute } from '@angular/router';
import { BaseComponent } from 'src/shared/base.component';
import { AuthService } from 'src/services/auth.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-training-course-view',
  templateUrl: './training-course-view.component.html',
  styleUrls: ['./training-course-view.component.css']
})
export class TrainingCourseViewComponent extends BaseComponent {

  item = null;

  constructor(
    private trainingCourseHttpService: TrainingCourseHttpService,
    private authService: AuthService,
    private activatedRoute: ActivatedRoute) {
    super();
  }

  ngOnInit(): void {
    const snapshot = this.activatedRoute.snapshot
    const id = snapshot.params.id;
    this.get(id);
  }

  get(id) {
    this.subscribe(this.trainingCourseHttpService.get(id),
      (res: any) => {
        this.item = res.data;
        this.item.course.imageUrl = (this.item.course.imageUrl) ? `${environment.serverUri}/${this.item.course.imageUrl}` : 'https://via.placeholder.com/200';

      },
      err => { }
    );
  }

  apply(item) {
    if (this.authService.isAuthenticated()) {
      this.goTo(`/course/${item.id}/apply`);
    }
    else {
      this.goTo(`/login?redirect=/course/${item.id}/apply`);
    }
  }



}
