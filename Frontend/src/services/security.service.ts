import { Injectable } from '@angular/core';

@Injectable()
export class SecurityService {

    private _storage: Storage;
    private authDataKey = 'otms_front_end_app_auth_data';
    private rememberMeTokenKey = 'remember_me';

    constructor() {
        this._storage = sessionStorage;
    }

    public setUserAccessible(data)  {
        var key = this.authDataKey + "_accessibles";
        if (data) {
            this._storage.removeItem(key);
            this._storage.setItem(key, JSON.stringify(data));
        } else {
            this._storage.removeItem(key);
        }
    }

    public getUserAccessible() {
        var key = this.authDataKey + "_accessibles";
        return JSON.parse(this._storage.getItem(key));
    }

    public setAuthData(data: IAuthData): void {
        if (data) {
            this._storage.removeItem(this.authDataKey);
            this._storage.setItem(this.authDataKey, JSON.stringify(data));
        } else {
            this._storage.removeItem(this.authDataKey);
        }
    }

    public getAuthData(): IAuthData {
        return <IAuthData>JSON.parse(this._storage.getItem(this.authDataKey));
    }

    public removeAuthData(): void {
        this._storage.removeItem(this.authDataKey);
    }

    public setRememberMeToken(data: string): void {
        if (data) {
            this._storage.setItem(this.rememberMeTokenKey, data);
        } else {
            this._storage.removeItem(this.rememberMeTokenKey);
        }
    }

    public getRememberMeToken(): string {
        return this._storage.getItem(this.rememberMeTokenKey);
    }

    public getAccessTokenData(key: string) {
        const authData = this.getAuthData();
        if (authData) {
            const accessTokenData = this.getDataFromToken(authData.accessToken);
            if (accessTokenData) {
                return accessTokenData[key];
            }
        }
        return null;
    }

    public getUserId() {
        return this.getAccessTokenData('user_id');
    }

    public getUserEmail() {
        return this.getAccessTokenData('user_email');
    }

    public getDataFromToken(token: any) {
        let data = {};
        if (typeof token !== 'undefined') {
            const encoded = token.split('.')[1];
            data = JSON.parse(this.urlBase64Decode(encoded));
        }
        return data;
    }

    public getCookie(cookieName) {
        const name = cookieName + '=';
        const decodedCookie = decodeURIComponent(document.cookie);
        const ca = decodedCookie.split(';');
        for (let i = 0; i < ca.length; i++) {
            let c = ca[i];
            while (c.charAt(0) === ' ') {
                c = c.substring(1);
            }
            if (c.indexOf(name) === 0) {
                return c.substring(name.length, c.length);
            }
        }
        return '';
    }

    private urlBase64Decode(str: string) {
        let output = str.replace('-', '+').replace('_', '/');
        switch (output.length % 4) {
            case 0:
                break;
            case 2:
                output += '==';
                break;
            case 3:
                output += '=';
                break;
        }

        return window.atob(output);
    }

}

export interface IAuthData {
    accessToken: string;
    refreshToken: string;
    expiresIn: number;
    userId: number
}
