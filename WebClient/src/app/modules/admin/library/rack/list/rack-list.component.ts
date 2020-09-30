import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { forkJoin } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { RackHttpService } from 'src/services/http/rack-http.service';
import { IButton } from 'src/app/shared/table-actions.component';

@Component({
  selector: 'app-rack-list',
  templateUrl: './rack-list.component.html'
})
export class RackListComponent extends TableComponent {

  @Searchable("Name", "like") name;
  @Searchable("FloorNo", "like") floorNo;
  @Searchable("BuildingName", "like") buildingName;

  buttons: IButton[] = [
    {
      label: 'edit',
      action: d => this.add(d),
      permissions: ['rack.manage', 'rack.update'],
      icon: 'edit'
    },
    {
      label: 'delete',
      action: d => this.delete(d),
      permissions: ['rack.manage', 'rack.delete'],
      icon: 'delete'
    }
  ]
  
  constructor(
    private rackHttpService: RackHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(rackHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/library/racks/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/library/racks/add');
    }
  }

  gets(pagination = null, search = null) {
    this.loading = true;
    const request = [
      this.rackHttpService.list(pagination, search)
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
