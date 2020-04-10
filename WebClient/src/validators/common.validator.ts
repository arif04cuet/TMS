import { Injectable } from '@angular/core';
import { FormControl } from '@angular/forms';
import { of } from 'rxjs';
import { BaseComponent } from '../app/shared/base.component';

@Injectable()
export class CommonValidator extends BaseComponent {

    required(control: FormControl) {
        if (!control.value) {
            return this.error('this.field.is.required');
        }
        return of(true);
    }

}