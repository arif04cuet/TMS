import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { AuthService } from './auth.service';

/**
 * Identity service (to Identity Web API controller).
 */
@Injectable() export class IdentityService {

    constructor(
        private http: HttpClient,
        private authService: AuthService) {
    }

}
