import { Component } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { forkJoin } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { SubjectHttpService } from 'src/services/http/subject-http.service';
import { SubjectAddComponent } from '../add/subject-add.component';
import { NzModalService } from 'ng-zorro-antd';
import { IButton } from 'src/app/shared/table-actions.component';
import { Searchable } from 'src/decorators/searchable.decorator';

@Component({
  selector: 'app-subject-list',
  templateUrl: './subject-list.component.html'
})
export class SubjectListComponent extends TableComponent {

  @Searchable("Name", "like") name;

  buttons: IButton[] = [
    {
      label: 'edit',
      action: d => this.add(d),
      permissions: ['book.category.manage', 'book.category.update'],
      icon: 'edit'
    },
    {
      label: 'delete',
      action: d => this.delete(d),
      permissions: ['book.category.manage', 'book.category.delete'],
      icon: 'delete'
    }
  ]

  constructor(
    private subjectHttpService: SubjectHttpService,
    private activatedRoute: ActivatedRoute,
    private modalService: NzModalService
  ) {
    super(subjectHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();

    this.onDeleted = (res: any) => {
      this.gets();
    }
  }

  add(model = null) {
    this.addModal(SubjectAddComponent, this.modalService, { id: model?.id });
  }

  gets(pagination = null, search = null) {
    this.loading = true;
    const request = [
      this.subjectHttpService.list(pagination, search)
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
    this.gets(null, null);
  }

  search() {
    this.gets(null, this.getSearchTerms())
  }

}
