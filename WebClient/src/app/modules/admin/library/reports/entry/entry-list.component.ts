import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { LibraryReportHttpService } from 'src/services/http/library-report-http.service';
import { createAnchorAndFireForDownload, progress } from 'src/services/utilities.service';

@Component({
  selector: 'app-entry-list',
  templateUrl: './entry-list.component.html'
})
export class EntryListComponent extends TableComponent {

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
      return this.libraryReportHttpService.bookEntries(p, s);
    });
  }

  print() {
    this.subscribe(this.libraryReportHttpService.printBookEntries(),
      res => progress(res, null, (data: Blob) => {
        createAnchorAndFireForDownload(data, "export-entries.csv");
        this.success('success');
      })
    );
  }

}
