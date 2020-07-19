import { Component, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SelectComponent } from 'src/app/shared/select/select.component';
import { NzModalService } from 'ng-zorro-antd';
import { FormComponent } from 'src/app/shared/form.component';
import { AllocationHttpService } from 'src/services/http/hostel/allocation-http.service';
import { CommonValidator } from 'src/validators/common.validator';

@Component({
  selector: 'app-batch-checkout-modal',
  templateUrl: './batch-checkout-modal.component.html'
})
export class BatchCheckoutModalComponent extends FormComponent {

  @ViewChild('batchSelect') batchSelect: SelectComponent;

  constructor(
    private allocationHttpService: AllocationHttpService,
    private activatedRoute: ActivatedRoute,
    private modal: NzModalService,
    private v: CommonValidator
  ) {
    super();
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.createForm({
      batchSchedule: [null, [], this.v.required.bind(this)]
    });
  }

  ngAfterViewInit() {
    this.batchSelect.register((pagination, search) => {
      return this.allocationHttpService.batchSchedules(pagination, search);
    }).fetch();
  }

  close() {
    this.modal.closeAll();
  }

  checkout() {
    this.log('batch checkout');
    this.validateForm(() => {
      const body = this.form.value;
      this.subscribe(this.allocationHttpService.batchSchedulesCheckout(body),
        (res: any) => { },
        err => { }
      );
    });

  }

}
