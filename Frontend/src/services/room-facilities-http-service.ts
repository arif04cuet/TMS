import { Injectable } from '@angular/core';
import { BaseHttpService } from './base-http-service';

@Injectable()
export class RoomFacilitiesHttpService extends BaseHttpService {

    public END_POINT = "hostels/facilities";


}