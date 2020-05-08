import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { AccessoryHttpService } from 'src/services/http/asset/accessory-http.service';


@Component({
  selector: 'app-accessory-checkout-history',
  templateUrl: './accessory-checkout-history.component.html'
})
export class AccessoryCheckoutHistoryComponent extends TableComponent {

  @Searchable("Name", "like") Name;

  private id;

  constructor(
    private accessoryHttpService: AccessoryHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(accessoryHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.id = this._activatedRouteSnapshot.params.id;
    this.load();
  }

  search() {
    this.load();
  }

  refresh() {
    this.load();
  }

  load() {
    super.load((p, s) => {
      return this.accessoryHttpService.listCheckoutHistory(this.id, p, s);
    })
  }

}
