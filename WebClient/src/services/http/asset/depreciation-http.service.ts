import { Injectable } from '@angular/core';
import { AssetBaseHttpService } from './asset-http-service';

@Injectable()
export class DepreciationHttpService extends AssetBaseHttpService {

    EndPoint = 'depreciations';

}