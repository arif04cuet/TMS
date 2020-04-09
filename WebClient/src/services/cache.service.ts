import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Subscriber } from 'rxjs';
import { of } from 'rxjs';
import { HttpService } from './http/http.service';

@Injectable()
export class CacheService {

    private _cache;

    constructor(private httpService: HttpService) {
        this._cache = {};
    }

    get(url: string) {

        let subscriber: Subscriber<any> = null;
        const newObservable: Observable<any> = new Observable(observer => subscriber = observer);

        const data = this._cache[url];
        if (data) {
            return of(data);
        } else {
            const subscription = this.httpService.get(url).subscribe(
                success => {
                    subscriber.next(success);
                    subscriber.complete();
                    this._cache[url] = success;
                    subscription.unsubscribe();
                },
                error => {
                    subscriber.error(error);
                    subscriber.complete();
                    subscription.unsubscribe();
                }
            );
        }
        return newObservable;
    }

    set(key: string, value: any) {
        return this._cache[key] = value;
    }

    remove(key: string) {
        delete this._cache[key];
    }

}

export const CACHE_KEYS = {
    
};
