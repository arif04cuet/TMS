import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { forkJoin } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { PublisherHttpService } from 'src/services/http/publisher-http.service';

@Component({
  selector: 'app-publisher-list',
  templateUrl: './publisher-list.component.html'
})
export class PublisherListComponent extends TableComponent {

  constructor(
    private publisherHttpService: PublisherHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(publisherHttpService);
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
      this.goTo(`/admin/library/publishers/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/library/publishers/add');
    }
  }

  gets(pagination = null, search = null) {
    this.loading = true;
    const request = [
      this.publisherHttpService.list()
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
