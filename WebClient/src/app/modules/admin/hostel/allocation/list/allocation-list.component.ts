import { Component, Type } from '@angular/core';
import { TableComponent } from 'src/app/shared/table.component';
import { ActivatedRoute } from '@angular/router';
import { Searchable } from 'src/decorators/searchable.decorator';
import { environment } from 'src/environments/environment';
import { AllocationHttpService } from 'src/services/http/hostel/allocation-http.service';
import { BatchCheckoutModalComponent } from '../batch-checkout-modal/batch-checkout-modal.component';
import { NzModalService } from 'ng-zorro-antd';

@Component({
  selector: 'app-allocation-list',
  templateUrl: './allocation-list.component.html'
})
export class AllocationListComponent extends TableComponent {

  @Searchable("Name", "like") name;
  @Searchable("Hostel.Name", "like") hostel;

  serverUrl = environment.serverUri;
  rowItemDisabledFilterKey = "checkoutDate";

  constructor(
    private allocationHttpService: AllocationHttpService,
    private activatedRoute: ActivatedRoute,
    private modal: NzModalService
  ) {
    super(allocationHttpService);
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.gets();
  }

  add(model = null) {
    if (model) {
      this.goTo(`/admin/hostels/allocations/${model.id}/edit`);
    }
    else {
      this.goTo('/admin/hostels/allocations/add');
    }
  }

  batchCheckout() {
    const modal = this.createModal(BatchCheckoutModalComponent);
    this.subscribe(modal.afterClose, res => {
      // this.additionalInfo = modal.getContentComponent().selectedBed;
      // if (this.additionalInfo) {
      //   this.form.controls.bed.setValue(this.additionalInfo.id);
      //   this.form.controls.room.setValue(null);
      // }
    });
  }

  createModal<T>(component: Type<T>) {
    return this.modal.create({
      nzWidth: '50%',
      nzContent: component,
      nzGetContainer: () => document.body,
      nzComponentParams: {},
      nzFooter: null
    });
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

  checkout(model) {
    if (model) {
      this.goTo(`/admin/hostels/allocations/${model.id}/checkout`);
    }
  }

  cancel(model) {
    if (model) {
      this.subscribe(this.allocationHttpService.cancel(model.id),
        (res: any) => {
          this.refresh();
        },
        err => { }
      );
    }
  }

}
