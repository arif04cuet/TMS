import { Injectable } from '@angular/core';
import { BaseHttpService } from '../asset/base-http-service';

@Injectable()
export class CourseHttpService extends BaseHttpService {

    END_POINT = 'courses';

    deleteImage(imageId, courseId = null) {
        const url = `${this.END_POINT}/${courseId}/images/${imageId}`
        return this.httpService.delete(url);
    }

}