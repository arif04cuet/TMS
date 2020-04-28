import { Injectable } from '@angular/core';
import { AssetBaseHttpService } from './asset-http-service';

@Injectable()
export class SupplierHttpService extends AssetBaseHttpService {

    EndPoint = 'suppliers';

}