import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TableComponent } from 'src/app/shared/table.component';
import { NzModalService } from 'ng-zorro-antd';
import { TopicHttpService } from 'src/services/http/course/topic-http.service';
import { Searchable } from 'src/decorators/searchable.decorator';

@Component({
  selector: 'app-topics-modal',
  templateUrl: './topics-modal.component.html'
})
export class TopicsModalComponent extends TableComponent {

  @Searchable("Name", "like") name;

  selectedTopic;

  constructor(
    private topicHttpService: TopicHttpService,
    private activatedRoute: ActivatedRoute,
    private modal: NzModalService
  ) {
    super(topicHttpService);
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
      let search;
      if(this.name) {
        search += `&Search=Name like ${this.name}`;
      }
      return this.topicHttpService.list(p, search);
    });
  }

  select(e) {
    this.selectedTopic = e;
    this.modal.closeAll();
  }

}
