import { Injectable } from '@angular/core';
import { BaseHttpService } from '../asset/base-http-service';

@Injectable()
export class ContentHttpService extends BaseHttpService {

    END_POINT = 'cms/contents';

    deleteImage(imageId, entityId = null) {
        const url = `${this.END_POINT}/${entityId}/images/${imageId}`
        return this.httpService.delete(url);
    }


    deleteAttachment(attachmentId, entityId = null) {
        const url = `${this.END_POINT}/${entityId}/attachments/${attachmentId}`
        return this.httpService.delete(url);
    }

}