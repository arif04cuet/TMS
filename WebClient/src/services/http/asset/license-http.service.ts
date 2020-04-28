import { Injectable } from '@angular/core';
import { AssetBaseHttpService } from './asset-http-service';

@Injectable()
export class LicenseHttpService extends AssetBaseHttpService {

    EndPoint = 'licenses';


}