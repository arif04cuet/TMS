import { Component, ViewChild } from '@angular/core';
import { TrainingCourseHttpService } from 'src/services/training-course-http-service';
import { TableComponent } from 'src/shared/table.component';
import { SelectComponent } from 'src/shared/select/select.component';
import { of } from 'rxjs';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-training-course',
  templateUrl: './training-course.component.html',
  styleUrls: ['./training-course.component.css']
})
export class TrainingCourseComponent extends TableComponent {

  @ViewChild('statusSelect') statusSelect: SelectComponent;
  @ViewChild('categorySelect') categorySelect: SelectComponent;

  status;
  category;
  
  constructor(
    private trainingCourseHttpService: TrainingCourseHttpService) {
    super(trainingCourseHttpService);
  }

  ngOnInit(): void {
    this.load2();
  }

  ngAfterViewInit() {
    this.statusSelect.register((pagination, search) => {
      const data = {
        data: {
          items: [
            { id: 'UPCOMING', name: 'Upcoming' },
            { id: 'RUNNING', name: 'Running' },
            { id: 'FINISHED', name: 'Finished' }
          ],
          size: 3
        }
      }
      return of(data);
    }).fetch();

    this.categorySelect.register((pagination, search) => {
      return this.trainingCourseHttpService.categories(pagination, search);
    }).fetch();
  }

  load2() {
    this.load((p, s) => {
      let search;
      if (this.category) {
        search = `Search=CourseSchedule.Course.CategoryId eq ${this.category}`
      }
      return this.trainingCourseHttpService.list2(this.status, search).pipe(
        map((x:any)=>{
          
          x.data.items.forEach(o => {
            o.course.imageUrl = (o.course.imageUrl) ? `${environment.serverUri}/${o.course.imageUrl}`:'https://via.placeholder.com/200';
          });
          
          return x;
        })
      );
    })
  }

  statusChanged(e) {
    this.status = e;
    this.load2();
  }


  categoryChanged(e) {
    this.category = e;
    this.load2();
  }

  log(e) {
    console.log(e);
  }

  view(item) {
    if (item) {
      this.goTo(`/course/${item.id}`);
    }
  }

}
