import { Injectable } from '@angular/core';
import { BaseHttpService } from '../asset/base-http-service';

@Injectable()
export class AllocationHttpService extends BaseHttpService {
    END_POINT = 'hostels/allocations';

    getRent(allocationId, checkoutDate) {
        const url = `${this.END_POINT}/${allocationId}/rent?checkout=${checkoutDate}`;
        return this.httpService.get(url);
    }

    batchSchedules(pagination, search) {
        const url = `${this.END_POINT}/batch-schedules`;
        return this.httpService.get(this.buildUrl(url, pagination, search))
    }

    batchSchedulesCheckout(body) {
        const url = `${this.END_POINT}/batch-schedule-checkout`;
        return this.httpService.post(url, body);
    }

    checkout(id, body) {
        const url = `${this.END_POINT}/${id}/checkout`;
        return this.httpService.put(url, body);
    }

    cancel(id) {
        const url = `${this.END_POINT}/${id}/cancel`;
        return this.httpService.put(url, null);
    }
}