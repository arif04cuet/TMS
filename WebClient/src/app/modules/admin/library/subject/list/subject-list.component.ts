import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { forkJoin } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { SubjectHttpService } from 'src/services/http/subject-http.service';

@Component({
  selector: 'app-subject-list',
  templateUrl: './subject-list.component.html'
})
export class SubjectListComponent extends TableComponent {

  constructor(
    private subjectHttpService: SubjectHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(subjectHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
    
    this.onDeleted = (res: any) => {
      this.gets();
    }
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/library/subjects/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/library/subjects/add');
    }
  }

  gets(pagination = null, search = null) {
    this.loading = true;
    const request = [
      this.subjectHttpService.list()
    ]
    this.subscribe(forkJoin(request),
      (res: any) => {
        this.fill(res[0]);
      },
      err => {
        console.log(err);
        this.loading = false;
      }
    );
  }

  refresh() {
    this.gets(null, null);
  }

}
