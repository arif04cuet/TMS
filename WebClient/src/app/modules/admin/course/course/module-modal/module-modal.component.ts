import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TableComponent } from 'src/app/shared/table.component';
import { NzModalService } from 'ng-zorro-antd';
import { ModuleHttpService } from 'src/services/http/course/module-http.service';
import { Searchable } from 'src/decorators/searchable.decorator';

@Component({
  selector: 'app-module-modal',
  templateUrl: './module-modal.component.html'
})
export class ModuleModalComponent extends TableComponent {

  selectedItem;
  @Searchable("Name", "like") name;

  constructor(
    private moduleHttpService: ModuleHttpService,
    private activatedRoute: ActivatedRoute,
    private modal: NzModalService
  ) {
    super(moduleHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
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

  load() {
    super.load((p, s) => {
      let search;
      if(this.name) {
        search += `&Search=Name like ${this.name}`;
      }
      return this.moduleHttpService.list(p, search);
    });
  }

  select(e) {
    this.selectedItem = e;
    this.modal.closeAll();
  }

  close() {
    this.modal.closeAll();
  }

}
