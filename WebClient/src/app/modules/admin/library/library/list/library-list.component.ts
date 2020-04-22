import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { forkJoin } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { LibraryHttpService } from 'src/services/http/library-http.service';
import { Searchable } from 'src/decorators/searchable.decorator';

@Component({
  selector: 'app-library-list',
  templateUrl: './library-list.component.html'
})
export class LibraryListComponent extends TableComponent {

  librarians = [];

  @Searchable("Name", "like") name;
  @Searchable("LibrarianId", "eq") librarian;

  constructor(
    private libraryHttpService: LibraryHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(libraryHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/libraries/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/libraries/add');
    }
  }

  gets(pagination = null, search = null) {
    this.loading = true;
    const request = [
      this.libraryHttpService.list(pagination, search),
      this.libraryHttpService.listLibrarians()
    ]
    this.subscribe(forkJoin(request),
      (res: any) => {
        this.fill(res[0]);
        this.librarians = res[1].data.items;
      },
      err => {
        console.log(err);
        this.loading = false;
      }
    );
  }

  refresh() {
    this.gets(null, this.getSearchTerms());
  }

  search() {
    this.gets(null, this.getSearchTerms())
  }

}