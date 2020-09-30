import { Component, ViewChild } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { environment } from 'src/environments/environment';
import { ContentHttpService } from 'src/services/http/cms/content-http.service';
import { CategoryHttpService } from 'src/services/http/cms/category-http.service';
import { SelectComponent } from 'src/app/shared/select/select.component';
import { IButton } from 'src/app/shared/table-actions.component';

@Component({
  selector: 'app-cms-content-list',
  templateUrl: './content-list.component.html'
})
export class CmsContentListComponent extends TableComponent {

  @ViewChild('categorySelect') categorySelect: SelectComponent;
  @Searchable("Name", "like") name;
  serverUrl = environment.serverUri;

  buttons: IButton[] = [
    {
      label: 'edit',
      action: d => this.add(d),
      permissions: ['content.manage', 'content.update'],
      icon: 'edit'
    },
    {
      label: 'delete',
      action: d => this.delete(d),
      permissions: ['content.manage', 'content.delete'],
      icon: 'delete'
    }
  ]

  constructor(
    private contentHttpService: ContentHttpService,
    private activatedRoute: ActivatedRoute,
    private categoryHttpService: CategoryHttpService,
  ) {
    super(contentHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
  }

  ngAfterViewInit() {
    this.categorySelect.register((pagination, search) => {
      return this.categoryHttpService.list(pagination, search);
    }).fetch();

  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/cms/contents/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/cms/contents/add');
    }
  }

  gets() {
    this.load();
  }

  refresh() {
    this.load();
  }

  search() {
    this.internalLoad();
  }


  internalLoad() {
    this.load((p, s) => {
      return this.contentHttpService.list(p, this.getSearch());
    });
  }

  getSearch() {
    let search = '';
    if (this.categorySelect?.value) {
      search += `Search=CategoryId eq ${this.categorySelect.value}`;
    }
    return search;
  }
}
