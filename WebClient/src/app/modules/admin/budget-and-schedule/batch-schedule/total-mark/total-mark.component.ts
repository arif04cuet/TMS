import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';
import { TableComponent } from 'src/app/shared/table.component';
import { TotalMarksHttpService } from 'src/services/http/budget-and-schedule/total-marks-http.service';

@Component({
  selector: 'app-total-mark',
  templateUrl: './total-mark.component.html'
})
export class TotalMarkComponent extends TableComponent {

  loading: boolean = false;
  private batchScheduleId;

  constructor(
    private activatedRoute: ActivatedRoute,
    private totalMarksHttpService: TotalMarksHttpService,
    private v: CommonValidator
  ) {
    super(totalMarksHttpService);
  }

  ngOnInit(): void {

    const snapshot = this.activatedRoute.snapshot;
    this.batchScheduleId = snapshot.params.id;
    this.load();
  }

  submit(): void {
    // const body = {
    //   marks: this.items
    // }
    // this.subscribe(this.totalMarksHttpService.update(this.examId, body),
    //   res => {
    //     this.loading = false;
    //     this.success(MESSAGE_KEY.SUCCESSFULLY_UPDATED);
    //   },
    //   err => this.loading = false
    // );
  }

  load() {
    return super.load((p, s) => this.totalMarksHttpService.list(this.batchScheduleId, p, s));
  }

  refresh() {
    this.load();
  }

  markChanged(d, e) {
    const n = Number(e);
    if (n) {
      d.mark = n;
    }
  }

}
