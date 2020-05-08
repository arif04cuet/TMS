import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LicenseViewComponent } from './license-view.component';
import { LicenseViewRoutingModule } from './license-view-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { LicenseHttpService } from 'src/services/http/asset/license-http.service';
import { UserHttpService } from 'src/services/http/user/user-http.service';
import { LicenseDetailsModule } from './details/license-details.module';
import { LicenseSeatsModule } from './seats/license-seats.module';
import { LicenseCheckoutHistoryModule } from './history/license-checkout-history.module';


@NgModule({
  declarations: [
    LicenseViewComponent
  ],
  imports: [
    LicenseViewRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectControlModule,
    LicenseDetailsModule,
    LicenseSeatsModule,
    LicenseCheckoutHistoryModule
  ],
  exports: [LicenseViewComponent],
  providers: [
    CommonValidator,
    LicenseHttpService,
    UserHttpService
  ]
})
export class LicenseViewModule { }
