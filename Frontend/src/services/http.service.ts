import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpRequest } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable()
export class HttpService {

    constructor(
        private http: HttpClient
    ) {
        //
    }

    get(url: string) {
        return this.http.get(`${environment.baseUrl}/${url}`, { headers: this.getCommonHeader(), withCredentials: true });
    }

    post(url: string, body: any) {
        return this.http.post(`${environment.baseUrl}/${url}`, body/*, { headers: this.getCommonHeader() }*/);
    }

    postFromData(url: string, body: any) {
        return new HttpRequest('POST', `${environment.baseUrl}/${url}`, body, {
            reportProgress: true,
            //headers: this.getHttpHeaders()
        });
    }

    put(url: string, body: any) {
        return this.http.put(`${environment.baseUrl}/${url}`, body, { headers: this.getCommonHeader() });
    }

    delete(url: string) {
        return this.http.delete(`${environment.baseUrl}/${url}`, { headers: this.getCommonHeader() });
    }

    postFile(url: string, body: any) {
        //const httpHeaders = this.getHttpHeaders();
        return new HttpRequest('POST', `${environment.baseUrl}/${url}`, body, {
            reportProgress: true,
            //headers: httpHeaders
        });
    }

    download(url: string, body: any) {
        //const httpHeaders = this.getHttpHeaders();
        return new HttpRequest('POST', `${environment.baseUrl}/${url}`, body, {
            reportProgress: true,
            responseType: 'blob',
            //headers: httpHeaders
        });
    }

    // public getHttpHeaders(): HttpHeaders {
    //     const token = this.securityService.getAuthData();
    //     if (token) {
    //         const httpOptions = new HttpHeaders({
    //             // 'Content-Type':  'text/plain;charset=UTF-8',
    //             // 'Accept': 'application/file',
    //             // 'Access-Control-Allow-Origin': '*',
    //             // 'Access-Control-Allow-Methods': 'GET, POST, PATCH, PUT, DELETE, OPTIONS',
    //             // 'Access-Control-Allow-Headers': 'Origin, Content-Type, X-XSRF-TOKEN',
    //             // 'Authorization': `Bearer ${this.securityService.getAuthData().accessToken}`,
    //         });
    //         return httpOptions;
    //     }
    // }

    getClient() {
        return this.http;
    }

    public getCommonHeader() {
        const headers = {
            'Content-Type': 'application/json',
            'Accept': 'application/json',
            'Access-Control-Allow-Origin': '*',
            'Access-Control-Allow-Methods': 'GET, POST, PATCH, PUT, DELETE, OPTIONS',
            'Access-Control-Allow-Headers': 'Origin, Content-Type, X-XSRF-TOKEN'
        };
        // const token = this.securityService.getAuthData();
        // const t = `${localStorage.access_token}`;
        // if(t) {
        //     headers['Authorization'] = `Bearer ${t}`;
        // }
        // if (token) {
        //     // headers['Authorization'] = `Bearer ${this.securityService.getAuthData().accessToken}`;
        // }
        return headers;
    }

    // private getCommonHeaderForFormData() {
    //     const headers = {};
    //     const token = this.securityService.getAuthData();
    //     if (token) {
    //         headers['Authorization'] = `Bearer ${this.securityService.getAuthData().accessToken}`;
    //     }
    //     return headers;
    // }

}
