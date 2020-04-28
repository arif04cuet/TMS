import { Injectable } from '@angular/core';
import { AssetBaseHttpService } from './asset-http-service';

@Injectable()
export class ManufacturerHttpService extends AssetBaseHttpService {

    EndPoint = 'manufacturers';

}