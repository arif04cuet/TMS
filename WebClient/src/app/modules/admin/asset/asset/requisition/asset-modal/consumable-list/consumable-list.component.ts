import { Component, Input } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { ConsumableHttpService } from 'src/services/http/asset/consumable-http.service';
import { map } from 'rxjs/operators';


@Component({
  selector: 'app-requisition-consumable-list',
  templateUrl: './consumable-list.component.html'
})
export class ConsumableListComponent extends TableComponent {

  @Input() data: any;

  constructor(
    private consumableHttpService: ConsumableHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(consumableHttpService);
  }

  ngOnInit() {
    const snapshot = this.activatedRoute.snapshot;
    this.snapshot(snapshot);
    if (this.data && this.data.consumables) {
      this.setOfCheckedId = new Set<number>(this.data.consumables.map(x => x.id));
    }
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
      return this.consumableHttpService.listGroupByItemCode(p, s).pipe(
        map((x: any) => {
          x.data.items.map(y => {
            delete y.quantity;
            return y;
          });
          return x;
        })
      );
    });
  }

  ngOnDestroy() {
    if (this.data) {
      this.data.consumables = Array.from(this.setOfCheckedId).map(x => {
        return this.items.find(y => y.id == x);
      });
    }
  }

}
