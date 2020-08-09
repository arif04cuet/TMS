import { Component, Input } from '@angular/core';
import { CmsHttpService } from 'src/services/cms-http-service';
import { TableComponent } from 'src/shared/table.component';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { TrainingCourseHttpService } from 'src/services/training-course-http-service';

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.css']
})
export class CourseComponent extends TableComponent {

  //UPCOMING, RUNNING, FINISHED
 @Input() status:string = "RUNNING";
 @Input() count:number = 6;

  constructor(
    private trainingCourseHttpService: TrainingCourseHttpService) {
    super(trainingCourseHttpService);
  }


  ngOnInit(): void {
    this.list();
  }
  list() {
    this.load((p, s) => {
      
      s += `scheduleStatus=${this.status}`;
      p = `limit=${this.count}`;
      return this.trainingCourseHttpService.list(p, s).pipe(
        map((x:any)=>{
          
          x.data.items.forEach(o => {
            o.course.imageUrl = (o.course.imageUrl) ? `${environment.serverUri}/${o.course.imageUrl}`:'https://via.placeholder.com/180*185';
            o.course.description = (o.course.description)?o.course.description.substring(0,200):'';
          });
          
          return x;
        })
      );
    })
  }

  view(course)
  {
    this.goTo(`/course/${course.id}`);
  }


}
