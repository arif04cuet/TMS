import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { BaseHttpService } from './asset/base-http-service';

@Injectable()
export class PublisherHttpService extends BaseHttpService {

    END_POINT = "books/publishers";

}