import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { forkJoin } from 'rxjs';
import { ManufacturerHttpService } from 'src/services/http/asset/manufacturer-http.service';
import { CommonHttpService } from 'src/services/http/common-http.service';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';


@Component({
  selector: 'app-manufacturer-list',
  templateUrl: './manufacturer-list.component.html',
  styleUrls: ['./manufacturer-list.component.scss']
})
export class ManufacturerListComponent extends TableComponent {

  statuses = [
    { id: true, name: 'Active' },
    { id: false, name: 'In Active' }
  ];

  @Searchable("Name", "like") Name;
  @Searchable("SupportUrl", "like") SupportUrl;
  @Searchable("SupportEmail", "like") SupportEmail;
  @Searchable("SupportPhone", "like") SupportPhone;
  @Searchable("IsActive", "eq") IsActive;


  constructor(
    private manufacturerHttpService: ManufacturerHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(manufacturerHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();

    this.onDeleted = (res: any) => {
      this.gets();
    }
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/asset/manufacturers/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/asset/manufacturers/add');
    }
  }

  gets(pagination = null, search = null) {
    this.loading = true;
    const request = [
      this.manufacturerHttpService.list(pagination, search)
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

  search() {
    this.gets(null, this.getSearchTerms())
  }

  refresh() {
    this.resetFilters();
    this.gets(null, null);
  }

  resetFilters() {
    this.Name = this.SupportEmail = this.SupportUrl = this.SupportPhone = this.IsActive = '';
  }

}
