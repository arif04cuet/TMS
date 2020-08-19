import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BaseComponent } from 'src/app/shared/base.component';
import { AdminHttpService } from 'src/services/http/admin-http.service';
import { forkJoin } from 'rxjs';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html'
})
export class DashboardComponent extends BaseComponent {

  loading: boolean = true;
  library: any = {};
  hostel: any = {};
  training: any = {};
  inventory: any = {};

  constructor(
    private activatedRoute: ActivatedRoute,
    private adminHttpService: AdminHttpService
  ) {
    super();
  }

  ngOnInit(): void {
    this.get();
  }

  get() {
    this.loading = true;
    const requests = forkJoin([
      this.adminHttpService.inventoryDashboard(),
      this.adminHttpService.hostelDashboard(),
      this.adminHttpService.libraryDashboard(),
      this.adminHttpService.trainingDashboard()
    ]);
    this.subscribe(requests,
      (res: any) => {
        this.loading = false;

        this.inventory = res[0].data;
        if (!this.inventory.reorderAlert) {
          this.inventory.reorderAlert = [];
        }
        if (!this.inventory.currentStock) {
          this.inventory.currentStock = {};
        }

        this.hostel = res[1].data;
        this.library = res[2].data;
        this.training = res[3].data;
      },
      err => { this.loading = false; }
    )
  }

  goToReorderAlert(e) {
    if (e && e.id) {
      this.goTo(`/admin/asset/consumables/${e.id}/items`);
    }
  }

}
