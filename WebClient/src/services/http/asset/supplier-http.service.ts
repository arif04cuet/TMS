import { Injectable } from '@angular/core';
import { BaseHttpService } from './base-http-service';

@Injectable()
export class SupplierHttpService extends BaseHttpService {

    END_POINT = 'asset/suppliers';

}