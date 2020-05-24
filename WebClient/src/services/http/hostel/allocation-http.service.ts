import { Injectable } from '@angular/core';
import { BaseHttpService } from '../asset/base-http-service';

@Injectable()
export class AllocationHttpService extends BaseHttpService {
    END_POINT = 'hostels/allocations';
}