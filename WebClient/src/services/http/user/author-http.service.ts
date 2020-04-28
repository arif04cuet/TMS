import { Injectable } from '@angular/core';
import { BaseHttpService } from '../asset/base-http-service';

@Injectable()
export class AuthorHttpService extends BaseHttpService {
    END_POINT = 'books/authors';
}