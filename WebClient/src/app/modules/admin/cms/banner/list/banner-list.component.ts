import { Component, ViewChild } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { environment } from 'src/environments/environment';
import { BannerHttpService } from 'src/services/http/cms/banner-http.service';
import { map, catchError } from 'rxjs/operators';
import { IButton } from 'src/app/shared/table-actions.component';

@Component({
  selector: 'app-cms-banner-list',
  templateUrl: './banner-list.component.html'
})
export class BannerListComponent extends TableComponent {

  @Searchable("Name", "like") name;
  serverUrl = environment.serverUri;

  buttons: IButton[] = [
    {
      label: 'edit',
      action: d => this.add(d),
      permissions: ['content.banner.manage', 'content.banner.update'],
      icon: 'edit'
    },
    {
      label: 'delete',
      action: d => this.delete(d),
      permissions: ['content.banner.manage', 'content.banner.delete'],
      icon: 'delete'
    }
  ]

  constructor(
    private bannerHttpService: BannerHttpService,
    private activatedRoute: ActivatedRoute
  ) {
    super(bannerHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/cms/banners/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/cms/banners/add');
    }
  }

  gets() {
    this.load((p, s) => {
      var list = this.bannerHttpService.list(p, s).pipe(
        map((x: any) => {
          x.data.items.forEach(o => {
            o.mediaUrl = `${environment.serverUri}/${o.mediaUrl}`;
          });
          return x;
        })
      );
      console.log(list);
      return list;
    });
  }

  refresh() {
    this.load();
  }

  search() {
    this.load();
  }

}
