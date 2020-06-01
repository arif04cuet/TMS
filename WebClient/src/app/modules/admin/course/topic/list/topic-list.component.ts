import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { environment } from 'src/environments/environment';
import { TopicHttpService } from 'src/services/http/course/topic-http.service';

@Component({
  selector: 'app-topic-list',
  templateUrl: './topic-list.component.html'
})
export class TopicListComponent extends TableComponent {

  @Searchable("Name", "like") name;

  serverUrl = environment.serverUri;

  constructor(
    private topicHttpService: TopicHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(topicHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/courses/topics/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/courses/topics/add');
    }
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

}
