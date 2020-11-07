import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { LibraryReportHttpService } from 'src/services/http/library-report-http.service';
import { createAnchorAndFireForDownload, progress } from 'src/services/utilities.service';

@Component({
  selector: 'app-new-list',
  templateUrl: './new-list.component.html'
})
export class NewListComponent extends TableComponent {

  constructor(
    private libraryReportHttpService: LibraryReportHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(libraryReportHttpService);
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
      return this.libraryReportHttpService.newBooks(p, s);
    });
  }

  print() {
    this.subscribe(this.libraryReportHttpService.printNewBooks(),
      res => progress(res, null, (data: Blob) => {
        createAnchorAndFireForDownload(data, "export-new-books.csv");
        this.success('success');
      })
    );
  }

}
