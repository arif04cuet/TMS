import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { environment } from 'src/environments/environment';
import { ResourcePersonHttpService } from 'src/services/http/course/resource-person-http.service';
import { IButton } from 'src/app/shared/table-actions.component';

@Component({
  selector: 'app-resource-person-list',
  templateUrl: './resource-person-list.component.html'
})
export class ResourcePersonListComponent extends TableComponent {

  @Searchable("Name", "like") name;
  @Searchable("ShortName", "like") shortName;
  @Searchable("Mobile", "like") mobile;
  @Searchable("Email", "like") email;

  serverUrl = environment.serverUri;

  buttons: IButton[] = [
    {
      label: 'edit',
      action: d => this.add(d),
      permissions: ['resource.person.manage', 'resource.person.update'],
      icon: 'edit'
    },
    {
      label: 'delete',
      action: d => this.delete(d),
      permissions: ['resource.person.manage', 'resource.person.delete'],
      icon: 'delete'
    }
  ]

  constructor(
    private resourcePersonHttpService: ResourcePersonHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(resourcePersonHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/courses/resource-persons/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/courses/resource-persons/add');
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
