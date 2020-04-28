import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { forkJoin } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { AuthorHttpService } from 'src/services/http/user/author-http.service';

@Component({
  selector: 'app-author-list',
  templateUrl: './author-list.component.html'
})
export class AuthorListComponent extends TableComponent {

  constructor(
    private authorHttpService: AuthorHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(authorHttpService);
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
      this.goTo(`/admin/library/authors/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/library/authors/add');
    }
  }

  gets(pagination = null, search = null) {
    this.loading = true;
    const request = [
      this.authorHttpService.list()
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
