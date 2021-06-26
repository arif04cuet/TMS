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
    return of(false);
  }

  email(control: FormControl) {
    let pattern = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

    if (!pattern.test(control.value)) {
      return this.error(MESSAGE_KEY.MUST_BE_EMAIL);
    }
    return of(true);
  }



  mobile(control: FormControl) {
    let pattern = /^(\d)+$/;

    if (!control.value) {
      return this.error(MESSAGE_KEY.THIS_FIELD_IS_REQUIRED);
    }
    else if (!pattern.test(control.value)) {
      return this.error(MESSAGE_KEY.MUST_BE_NUMERIC);
    }
    else if (control.value.length != 11) {
      return this.error(MESSAGE_KEY.MUST_BE_EQUAL_X0_CHARACTERS, { x0: 11 });
    }
    return of(true);
  }

  isbn(control: FormControl) {
    let pattern = /^(\d|-|x|X)+$/;

    if (!control.value) {
      return this.error(MESSAGE_KEY.THIS_FIELD_IS_REQUIRED);
    }
    else if (!pattern.test(control.value)) {
      return this.error(MESSAGE_KEY.MUST_BE_ISBN_NUMBER);
    }
    return of(true);
  }

  numberEnBn(control: FormControl) {

    var allowedKeys = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9",
      "ARROWRIGHT", "ARROWLEFT", "TAB", "BACKSPACE", "DELETE", "HOME", "END",
      "০", "১", "২", "৩", "৪", "৫", "৬", "৭", "৮", "৯"
    ];

    const value = control.value;

    if (!value) {
      return this.error(MESSAGE_KEY.THIS_FIELD_IS_REQUIRED);
    }

    const restrictedChars = value.toString().split('').filter(c => !allowedKeys.includes(c));

    if (restrictedChars.length)
      return this.error(MESSAGE_KEY.MUST_BE_NUMERIC);
    else
      return of(true);

  }

}