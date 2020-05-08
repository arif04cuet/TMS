import { Injectable } from '@angular/core';
import { BaseHttpService } from './base-http-service';

@Injectable()
export class AssetModelHttpService extends BaseHttpService {
    END_POINT = `asset/models`
}