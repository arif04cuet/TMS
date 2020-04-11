import { Injectable } from '@angular/core';
import { HttpService } from './http/http.service';
import { map } from 'rxjs/operators';
import { SecurityService } from './security.service';

@Injectable()
export class AuthService {

    public storage: Storage = localStorage;
    public redirectUrl: string;

    constructor(
        private httpService: HttpService,
        private securityService: SecurityService
    ) { }

    public init(): void {
        
    }

    public login(body) {
        return this.httpService.post('token', body).pipe(
            map((res: any) => {
                this.securityService.setAuthData(res.data);
                return res;
            })
        );
    }

    public logout() {
        this.securityService.removeAuthData();
    }

    public isAuthenticated() : boolean {
        const data = this.securityService.getAuthData();
        return data != null;
    }

    public getLoggedInUserInfo() {
        const data: any = this.securityService.getAuthData();
        return data.userInfo;
    }

    public getLoggedInUserId() {
        const data: any = this.securityService.getAuthData();
        return data.userId;
    }

}
