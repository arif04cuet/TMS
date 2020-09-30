import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { FaqHttpService } from 'src/services/http/cms/faq-http.service';
import { IButton } from 'src/app/shared/table-actions.component';

@Component({
  selector: 'app-cms-faq-list',
  templateUrl: './faq-list.component.html'
})
export class CmsFaqListComponent extends TableComponent {

  buttons: IButton[] = [
    {
      label: 'edit',
      action: d => this.add(d),
      permissions: ['content.faq.manage', 'content.faq.update'],
      icon: 'edit'
    },
    {
      label: 'delete',
      action: d => this.delete(d),
      permissions: ['content.faq.manage', 'content.faq.delete'],
      icon: 'delete'
    }
  ]

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
