import { Injectable } from '@angular/core';
import { BaseHttpService } from '../asset/base-http-service';
import { of } from 'rxjs';

@Injectable()
export class BatchScheduleAllocationHttpService extends BaseHttpService {

    END_POINT = 'trainings/batch-schedules/allocations';

    listStatus() {
        const data = {
            data: {
                items: [
                    { id: 1, name: 'Rejected' },
                    { id: 2, name: 'Approved' },
                    { id: 3, name: 'Waiting' }
                ],
                size: 3
            }
        }
        return of(data);
    }

    updateStatus(body: any) {
        const url = `${this.END_POINT}/status`;
        return this.httpService.put(url, body);
    }

    migrateToNextBatch(body: any) {
        const url = `${this.END_POINT}/migrate`;
        return this.httpService.put(url, body);
    }

    export(search) {
        const url = `${this.buildUrl(this.END_POINT + '/export')}${search}`;
        const req = this.httpService.download(url, {});
        return this.httpService.getClient().request(req);
    }

    downloadCertificate(batchScheduleAllocationId) {
        const url = `${this.END_POINT}/${batchScheduleAllocationId}/certificate`;
        const req = this.httpService.download(url, {});
        return this.httpService.getClient().request(req);
    }
}