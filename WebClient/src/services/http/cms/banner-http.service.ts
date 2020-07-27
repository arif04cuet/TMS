import { Injectable } from '@angular/core';
import { BaseHttpService } from '../asset/base-http-service';

@Injectable()
export class BannerHttpService extends BaseHttpService {

    END_POINT = 'cms/banners';

    deleteImage(imageId, entityId = null) {
        const url = `${this.END_POINT}/${entityId}/images/${imageId}`
        return this.httpService.delete(url);
    }

}