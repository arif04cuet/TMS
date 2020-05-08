import { Injectable } from '@angular/core';
import { AssetBaseHttpService } from './asset-http-service';

@Injectable()
export class ComponentHttpService extends AssetBaseHttpService {
    EndPoint = 'components';
}