import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { environment } from 'src/environments/environment';
import { FaqHttpService } from 'src/services/http/cms/faq-http.service';

@Component({
  selector: 'app-cms-faq-list',
  templateUrl: './faq-list.component.html'
})
export class CmsFaqListComponent extends TableComponent {

  constructor(
    private faqHttpService: FaqHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(faqHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/cms/faq/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/cms/faq/add');
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
