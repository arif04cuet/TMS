import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { LicenseHttpService } from 'src/services/http/asset/license-http.service';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { IButton } from 'src/app/shared/table-actions.component';


@Component({
  selector: 'app-license-list',
  templateUrl: './license-list.component.html'
})
export class LicenseListComponent extends TableComponent {

  statuses = [];

  @Searchable("Name", "like") Name;
  @Searchable("ProductKey", "like") ProductKey;
  @Searchable("IsActive", "eq") IsActive;

  buttons: IButton[] = [
    {
      label: 'checkout',
      action: d => this.checkout(d),
      condition: d => d.available,
      type: 'primary',
      permissions: ['license.manage', 'license.checkout']
    },
    {
      label: 'view',
      action: d => this.view(d),
      permissions: ['license.manage', 'license.view'],
      icon: 'eye'
    },
    {
      label: 'edit',
      action: d => this.add(d),
      permissions: ['license.manage', 'license.update'],
      icon: 'edit'
    },
    {
      label: 'delete',
      action: d => this.delete(d),
      permissions: ['license.manage', 'license.delete'],
      icon: 'delete'
    }
  ]

  constructor(
    private licenseHttpService: LicenseHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(licenseHttpService);
  }

  ngOnInit() {
    this.statuses = this.licenseHttpService.getStatus();
    this.snapshot(this.activatedRoute.snapshot);
    this.load();
    this.onDeleted = (res: any) => {
      this.load();
    }
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/asset/licenses/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/asset/licenses/add');
    }
  }

  view(model = null) {
    if (model) {
      this.goTo(`/admin/asset/licenses/${model.id}/view`);
    }
  }

  checkout(model = null) {
    if (model) {
      this.goTo(`/admin/asset/licenses/${model.id}/checkout`);
    }
  }

  search() {
    this.load();
  }

  refresh() {
    this.resetFilters();
    this.load();
  }

  resetFilters() {
    this.Name = this.ProductKey = this.IsActive = '';
  }

}
