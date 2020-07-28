import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CommonValidator } from 'src/validators/common.validator';
import { TableComponent } from 'src/app/shared/table.component';
import { TotalMarksHttpService } from 'src/services/http/budget-and-schedule/total-marks-http.service';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-total-mark',
  templateUrl: './total-mark.component.html'
})
export class TotalMarkComponent extends TableComponent {

  loading: boolean = false;

  private batchScheduleId;
  private data: any;

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
    const body = {
      marks: this.data
    }
    this.loading = true;
    this.subscribe(this.totalMarksHttpService.update(this.batchScheduleId, body),
      (res: any) => {
        this.loading = false;
        this.success('success');
      },
      err => {
        this.loading = false;
        this.failed('failed');
      }
    );
  }

  load() {
    return super.load((p, s) => this.totalMarksHttpService.list(this.batchScheduleId, p, s).pipe(
      map((x: any) => {
        this.data = x.data;
        return x
      })
    ));
  }

  refresh() {
    this.load();
  }

  onMarkChanged(data) {
    if (data.evaluationMethods && data.evaluationMethods.length > 0) {
      data.totalMark = data.evaluationMethods.map(x => x.mark).reduce((a, c) => a + c)
    }
  }

}
