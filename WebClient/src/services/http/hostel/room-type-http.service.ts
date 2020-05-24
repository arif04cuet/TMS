import { Injectable } from '@angular/core';
import { BaseHttpService } from '../asset/base-http-service';

@Injectable()
export class RoomTypeHttpService extends BaseHttpService {

    END_POINT = 'hostels/rooms/types';

}