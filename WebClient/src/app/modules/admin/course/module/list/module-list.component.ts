import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { ModuleHttpService } from 'src/services/http/course/module-http.service';
import { IButton } from 'src/app/shared/table-actions.component';

@Component({
  selector: 'app-module-list',
  templateUrl: './module-list.component.html'
})
export class ModuleListComponent extends TableComponent {

  @Searchable("Name", "like") name;
  @Searchable("Director.FullName", "like") director;

  buttons: IButton[] = [
    {
      label: 'edit',
      action: d => this.add(d),
      permissions: ['module.manage', 'module.update'],
      icon: 'edit'
    },
    {
      label: 'delete',
      action: d => this.delete(d),
      permissions: ['module.manage', 'module.delete'],
      icon: 'delete'
    }
  ]

  constructor(
    private moduleHttpService: ModuleHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(moduleHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/courses/modules/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/courses/modules/add');
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
