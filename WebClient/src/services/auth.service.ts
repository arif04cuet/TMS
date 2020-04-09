import { Injectable } from '@angular/core';

@Injectable() export class AuthService {

    public isAuthenticated: boolean = false;
    public storage: Storage = localStorage;
    public redirectUrl: string;

    constructor() { }

    public init(): void {
        this.isAuthenticated = true;
    }

    public signin(email: string, password: string) : void {

    }

}
