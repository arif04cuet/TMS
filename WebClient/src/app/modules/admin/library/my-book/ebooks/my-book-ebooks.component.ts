import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { BookHttpService } from 'src/services/http/user/book-http.service';
import { IButton } from 'src/app/shared/table-actions.component';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-my-book-ebooks',
  templateUrl: './my-book-ebooks.component.html'
})
export class MyBookEbooksComponent extends TableComponent {

  serverUrl = environment.serverUri;

  @Searchable("Book.Title", "like") title;

  buttons: IButton[] = [

  ]

  constructor(
    private bookHttpService: BookHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(bookHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
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

  load() {
    super.load((p, s) => {

      return this.bookHttpService.listEbooks(p, s)
    })
  }

}
