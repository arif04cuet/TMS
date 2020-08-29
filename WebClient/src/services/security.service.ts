import { Injectable } from '@angular/core';
import { state } from 'src/constants/state';

@Injectable()
export class SecurityService {

    private _storage: Storage;
    private authDataKey = 'otms_app_auth_data';
    private permissionDataKey = 'otms_app_permission_data';
    private rememberMeTokenKey = 'remember_me';

    private permissions: string[] = [];
    private authData: IAuthData = null;

    constructor() {
        this._storage = localStorage;
    }

    public setAuthData(data: IAuthData): void {
        if (data) {
            this.authData = data;
            this._storage.removeItem(this.authDataKey);
            this._storage.setItem(this.authDataKey, JSON.stringify(data));
        } else {
            this.authData = null;
            this._storage.removeItem(this.authDataKey);
        }
    }

    public setPermissions(permissions: string[]): void {
        state.permissionCache = {};
        if (permissions) {
            this.permissions = permissions;
            this._storage.removeItem(this.permissionDataKey);
            this._storage.setItem(this.permissionDataKey, JSON.stringify(permissions));
        } else {
            this.permissions = [];
            this._storage.removeItem(this.permissionDataKey);
        }
    }

    public getPermissions(): string[] {
        if (this.permissions && this.permissions.length) {
            return this.permissions;
        }
        else {
            const permissions = <string[]>JSON.parse(this._storage.getItem(this.permissionDataKey));
            this.permissions = permissions;
            return this.permissions;
        }
    }

    public getAuthData(): IAuthData {
        if(this.authData) {
            return <IAuthData>this.authData;
        }
        else {
            this.authData = <IAuthData>JSON.parse(this._storage.getItem(this.authDataKey));
            return this.authData;
        }
    }

    public removeAuthData(): void {
        this._storage.removeItem(this.authDataKey);
        this.authData = null;
    }

    public removePermissions(): void {
        this._storage.removeItem(this.permissionDataKey);
        this.permissions = [];
        state.permissionCache = {};
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
