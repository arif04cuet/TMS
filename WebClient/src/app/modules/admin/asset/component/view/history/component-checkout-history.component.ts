import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { ComponentHttpService } from 'src/services/http/asset/component-http.service';


@Component({
  selector: 'app-component-checkout-history',
  templateUrl: './component-checkout-history.component.html'
})
export class ComponentCheckoutHistoryComponent extends TableComponent {

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

  search() {
    this.load();
  }

  refresh() {
    this.load();
  }

  load() {
    super.load((p, s) => {
      return this.componentHttpService.listCheckoutHistory(this.id, p, s);
    })
  }

}
