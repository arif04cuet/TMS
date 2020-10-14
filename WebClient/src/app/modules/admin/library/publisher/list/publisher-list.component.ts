import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { forkJoin } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { PublisherHttpService } from 'src/services/http/publisher-http.service';
import { PublisherAddComponent } from '../add/publisher-add.component';
import { NzModalService } from 'ng-zorro-antd';
import { IButton } from 'src/app/shared/table-actions.component';
import { Searchable } from 'src/decorators/searchable.decorator';

@Component({
  selector: 'app-publisher-list',
  templateUrl: './publisher-list.component.html'
})
export class PublisherListComponent extends TableComponent {

  @Searchable("Name", "like") name;
  buttons: IButton[] = [
    {
      label: 'edit',
      action: d => this.add(d),
      permissions: ['publisher.manage', 'publisher.update'],
      icon: 'edit'
    },
    {
      label: 'delete',
      action: d => this.delete(d),
      permissions: ['publisher.manage', 'publisher.delete'],
      icon: 'delete'
    }
  ]

  constructor(
    private publisherHttpService: PublisherHttpService,
    private activatedRoute: ActivatedRoute,
    private modalService: NzModalService
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
    this.addModal(PublisherAddComponent, this.modalService, { id: model?.id });
  }

  gets(pagination = null, search = null) {
    this.loading = true;
    const request = [
      this.publisherHttpService.list(),
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
