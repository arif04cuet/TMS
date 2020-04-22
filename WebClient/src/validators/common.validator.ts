import { Injectable } from '@angular/core';
import { FormControl } from '@angular/forms';
import { of } from 'rxjs';
import { BaseComponent } from '../app/shared/base.component';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';

@Injectable()
export class CommonValidator extends BaseComponent {

    required(control: FormControl) {
        if (!control.value) {
            return this.error(MESSAGE_KEY.THIS_FIELD_IS_REQUIRED);
        }
        return of(true);
    }

}