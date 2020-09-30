import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { CourseHttpService } from 'src/services/http/course/course-http.service';
import { IButton } from 'src/app/shared/table-actions.component';

@Component({
  selector: 'app-course-list',
  templateUrl: './course-list.component.html'
})
export class CourseListComponent extends TableComponent {

  @Searchable("Name", "like") name;

  buttons: IButton[] = [
    {
      label: 'edit',
      action: d => this.add(d),
      permissions: ['course.manage', 'course.update'],
      icon: 'edit'
    },
    {
      label: 'delete',
      action: d => this.delete(d),
      permissions: ['course.manage', 'course.delete'],
      icon: 'delete'
    }
  ]

  constructor(
    private courseHttpService: CourseHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(courseHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/courses/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/courses/add');
    }
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

}
