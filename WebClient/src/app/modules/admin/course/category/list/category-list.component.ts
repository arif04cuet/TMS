import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { environment } from 'src/environments/environment';
import { CategoryHttpService } from 'src/services/http/course/category-http.service';
import { CategoryAddComponent } from '../../category/add/category-add.component';
import { NzModalService } from 'ng-zorro-antd';
import { IButton } from 'src/app/shared/table-actions.component';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html'
})
export class CategoryListComponent extends TableComponent {

  @Searchable("Name", "like") name;
  serverUrl = environment.serverUri;

  buttons: IButton[] = [
    {
      label: 'edit',
      action: d => this.add(d),
      permissions: ['course.category.manage', 'course.category.update'],
      icon: 'edit'
    },
    {
      label: 'delete',
      action: d => this.delete(d),
      permissions: ['course.category.manage', 'course.category.delete'],
      icon: 'delete'
    }
  ]

  constructor(
    private categoryHttpService: CategoryHttpService,
    private activatedRoute: ActivatedRoute,
    private modalService: NzModalService
  ) {
    super(categoryHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
  }

  add(model = null) {
    this.addModal(CategoryAddComponent, this.modalService, {id: model?.id});
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
