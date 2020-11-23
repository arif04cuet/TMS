import { Injectable } from '@angular/core';
import { BaseHttpService } from './asset/base-http-service';

@Injectable()
export class BookReservationHttpService extends BaseHttpService {
    END_POINT = "books/reservations"

    public assignableBookItems(pagination, search) {
        const url = this.buildUrl(`${this.END_POINT}/assignable-book-items`, pagination, search);
        return this.httpService.get(url);
    }

    public cancel(reservationId) {
        const url = `${this.END_POINT}/${reservationId}/cancel`;
        return this.httpService.post(url, {});
    }

    public issue(reservationId) {
        const url = `${this.END_POINT}/${reservationId}/issue`;
        return this.httpService.post(url, {});
    }
    public reserveBymember(body) {
        const url = `${this.END_POINT}/reserveBymember`;
        return this.httpService.post(url, body);
    }

}