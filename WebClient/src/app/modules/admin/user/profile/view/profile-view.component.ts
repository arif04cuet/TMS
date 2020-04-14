import { Component } from '@angular/core';
import { UserHttpService } from 'src/services/http/user-http.service';
import { BaseComponent } from 'src/app/shared/base.component';
import { AuthService } from 'src/services/auth.service';
import { DatePipe } from '@angular/common';
import { TimeAgoPipe } from 'src/pipes/time-ago.pipe';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-profile-view',
  templateUrl: './profile-view.component.html',
  styleUrls: ['./profile-view.component.scss']
})
export class ProfileViewComponent extends BaseComponent {

  loading: boolean = false;
  data: any = {}

  private userId;

  constructor(
    private userHttpService: UserHttpService,
    private authService: AuthService,
    private datePipe: DatePipe,
    private timeAgo: TimeAgoPipe,
    private activatedRoute: ActivatedRoute
  ) {
    super();
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
    this.userId = this.authService.getLoggedInUserId();
    this.get();
  }

  get() {
    this.subscribe(this.userHttpService.getProfile(this.userId),
      (res: any) => {
        this.transformDate(res, 'dateOfBirth');
        this.transformDate(res, 'joiningDate');
        this.transformEducation(res);
        this.transformOfficeAddress(res);
        this.data = res.data;
        this.loading = false;
      },
      (err: any) => {
        this.loading = false;
      }
    );
  }

  edit() {
    this.goTo(`/admin/profile/edit`)
  }

  private transformOfficeAddress(res) {
    if (res.data && res.data.officeAddress) {
      const arr: string[] = [];
      const oa = res.data.officeAddress;
      if (oa.contactName) {
        arr.push(oa.contactName);
      }
      if (oa.addressLine1) {
        arr.push(oa.addressLine1);
      }
      if (oa.addressLine2) {
        arr.push(oa.addressLine2);
      }
      res.data.officeAddress = arr.join(', ');
    }
  }

  private transformDate(res, property) {
    let date = res.data[property] ? this.datePipe.transform(res.data[property]) : ''
    if (date) {
      const timeAgo = this.timeAgo.transform(res.data[property]);
      date += ` (${timeAgo})`;
      res.data[property] = date;
    }
  }

  private transformEducation(res) {
    if (res.data.educations && res.data.educations.length > 0) {
      const e = res.data.educations[0];
      res.data.educations = {
        degree: e.degree,
        university: e.university,
        department: e.department,
        passingYear: e.passingYear,
        result: e.Result
      }
    }
    res.data.educations = {};
  }

}
