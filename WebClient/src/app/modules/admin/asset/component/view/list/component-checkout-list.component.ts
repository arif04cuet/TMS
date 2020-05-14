import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { ComponentHttpService } from 'src/services/http/asset/component-http.service';


@Component({
  selector: 'app-component-checkout-list',
  templateUrl: './component-checkout-list.component.html'
})
export class ComponentCheckoutListComponent extends TableComponent {

  @Searchable("Name", "like") Name;

  private id;

  constructor(
    private componentHttpService: ComponentHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(componentHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.id = this._activatedRouteSnapshot.params.id;
    this.load();
  }

  checkout() {
    this.goTo(`/admin/asset/components/${this.id}/checkout`);
  }

  checkin(id) {
    this.goTo(`/admin/asset/components/${this.id}/checkin?checkout=${id}`);
  }

  search() {
    this.load();
  }

  refresh() {
    this.load();
  }

  load() {
    super.load((p, s) => {
      return this.componentHttpService.listCheckouts(this.id, p, s);
    })
  }

  viewAsset(assetId) {
    this.goTo(`/admin/asset/${assetId}/view`);
  }

}
