import { Component, ViewChild } from '@angular/core';
import { BaseComponent } from 'src/app/shared/base.component';
import { ActivatedRoute } from '@angular/router';
import { ComponentHttpService } from 'src/services/http/asset/component-http.service';

@Component({
  selector: 'app-component-details',
  templateUrl: './component-details.component.html'
})
export class ComponentDetailsComponent extends BaseComponent {

  loading: boolean = true;
  item;

  constructor(
    private activatedRoute: ActivatedRoute,
    private componentHttpService: ComponentHttpService
  ) {
    super();
  }

  ngOnInit(): void {
    this._activatedRouteSnapshot = this.activatedRoute.snapshot
    const id = this.getQueryParams('id');
    this.get(id);
  }

  get(id) {
    this.loading = true;
    this.subscribe(this.componentHttpService.get(id),
      (res: any) => {
        this.item = res.data;
        this.loading = false;
      }
    );
  }

  cancel() {
    this.goTo('/admin/asset/components');
  }

}
