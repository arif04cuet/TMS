import { Injectable } from '@angular/core';
import { BaseHttpService } from '../asset/base-http-service';

@Injectable()
export class RoomHttpService extends BaseHttpService {

    END_POINT = 'hostels/rooms';

}