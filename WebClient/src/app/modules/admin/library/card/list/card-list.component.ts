import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { LibraryCardHttpService } from 'src/services/http/library-card-http.service';

@Component({
  selector: 'app-library-card-list',
  templateUrl: './card-list.component.html'
})
export class CardListComponent extends TableComponent {

  @Searchable("Barcode", "like") number;
  @Searchable("CardType.Name", "like") type;
  
  constructor(
    private libraryCardHttpService: LibraryCardHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(libraryCardHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.load();
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/library/cards/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/library/cards/add');
    }
  }

  refresh() {
    this.load();
  }

  search() {
    this.load()
  }

}
