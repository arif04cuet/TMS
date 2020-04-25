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

  mobile(control: FormControl) {
    if (!control.value) {
      return this.error(MESSAGE_KEY.THIS_FIELD_IS_REQUIRED);
    }
    else if (isNaN(control.value)) {
      return this.error(MESSAGE_KEY.MUST_BE_NUMERIC);
    }
    else if (control.value.length != 11) {
      return this.error(MESSAGE_KEY.MUST_BE_EQUAL_X0_CHARACTERS, { x0: 11 });
    }
    return of(true);
  }

}