import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { forkJoin } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { LibraryHttpService } from 'src/services/http/library-http.service';
import { Searchable } from 'src/decorators/searchable.decorator';
import { IButton } from 'src/app/shared/table-actions.component';

@Component({
  selector: 'app-library-list',
  templateUrl: './library-list.component.html'
})
export class LibraryListComponent extends TableComponent {

  @Searchable("Name", "like") name;
  @Searchable("LibrarianId", "eq") librarian;
  librarians = [];
  buttons: IButton[] = [
    {
      label: 'edit',
      action: d => this.add(d),
      permissions: ['library.manage', 'library.update'],
      icon: 'edit'
    },
    {
      label: 'delete',
      action: d => this.delete(d),
      permissions: ['library.manage', 'library.delete'],
      icon: 'delete'
    }
  ]


  constructor(
    private libraryHttpService: LibraryHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(libraryHttpService);
    this.onDeleteFailed = this.onDeleteFailedHandler.bind(this);
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

  onDeleteFailedHandler(res: any) {

  }

  handleError(error, redirect = '/login') {

    if (error && error.status === 500 && error.error.message == 'Something went wrong.') {

      this.failed('library.delete.failed');

    } else {
      super.handleError(error);
    }
  }


}
