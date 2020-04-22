import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { forkJoin } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { LibraryCardHttpService } from 'src/services/http/library-card-http.service';

@Component({
  selector: 'app-library-card-list',
  templateUrl: './card-list.component.html'
})
export class CardListComponent extends TableComponent {

  @Searchable("Name", "like") number;
  @Searchable("CardTypeId", "like") type;
  
  constructor(
    private libraryCardHttpService: LibraryCardHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(libraryCardHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/library/cards/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/library/cards/add');
    }
  }

  gets(pagination = null, search = null) {
    this.loading = true;
    const request = [
      this.libraryCardHttpService.list(pagination, search)
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
    this.gets(null, this.getSearchTerms());
  }

  search() {
    this.gets(null, this.getSearchTerms())
  }

}
