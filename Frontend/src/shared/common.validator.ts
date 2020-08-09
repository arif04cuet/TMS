import { Injectable } from '@angular/core';
import { FormControl } from '@angular/forms';
import { of } from 'rxjs';
import { BaseComponent } from './base.component';

@Injectable()
export class CommonValidator extends BaseComponent {

  required(control: FormControl) {
    if (!control.value) {
      return of({
        error: true,
        message: 'This field is required'
      });
    }
    return of(false);
  }

  mobile(control: FormControl) {
    if (!control.value) {
      return of({
        error: true,
        message: 'This field is required'
      });
    }
    else if (isNaN(control.value)) {
      return of({
        error: true,
        message: 'This field must be numeric'
      });
    }
    else if (control.value.length != 11) {
      return of({
        error: true,
        message: 'This field must be equal 11 characters'
      });
    }
    return of(true);
  }

}