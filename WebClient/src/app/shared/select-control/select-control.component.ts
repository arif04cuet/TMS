import { Component, Input, forwardRef, Output, EventEmitter } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR, FormControl } from '@angular/forms';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-select-control',
  templateUrl: './select-control.component.html',
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => SelectControlComponent),
      multi: true
    }
  ]
})
export class SelectControlComponent implements ControlValueAccessor {

  @Input() label;
  @Input() formControl: FormControl;
  @Output() onChange = new EventEmitter();
  @Input() labelKey = 'name';
  @Input() mandatory: boolean = false;

  loading: boolean = false;
  items = [];

  private _value;
  private propagateChange = (_: any) => { };

  private total: number = 0;
  private offset: number = 0;
  private limit: number = 20;
  private fetchFn: (pagination: string, search?: string) => Observable<Object>;
  private subscriptions = [];
  private _selectFirstOption = false;
  private _onLoadCompleted;

  get value() {
    return this._value;
  }

  set value(value) {
    this._value = value;
    this.propagateChange(this._value);
  }

  constructor() {
  }

  ngOnInit() {
  }

  writeValue(value: any) {
    this._value = value;
  }

  registerOnChange(fn) {
    this.propagateChange = fn;
  }

  registerOnTouched() {

  }

  register(fn: (pagination: string, search?: string) => Observable<Object>) {
    this.fetchFn = fn;
    return this;
  }

  fetch(search?: string) {
    if (this.fetchFn) {
      this.busy(true);
      const pagination = `offset=${this.offset}&limit=${this.limit}`;
      const subscription = this.fetchFn(pagination, search).subscribe(
        (res: any) => {
          this.items = res.data.items || [];
          this.busy(false);
          if (this._selectFirstOption && this.items.length > 0) {
            this._value = this.items[0].id;
            this.formControl.setValue(this._value);
          }
          if (this._onLoadCompleted) {
            this._onLoadCompleted();
          }
        },
        err => {
          this.busy(false);
        }
      );
      if (subscription) {
        this.subscriptions.push(subscription);
      }
    }
    return this;
  }

  fetchNext(search?: string) {
    this.offset = this.offset + this.limit;
    this.fetch(search);
  }

  selectFirstOption() {
    this._selectFirstOption = true;
    return this;
  }

  onValueChange(e) {
    if (this.onChange) {
      this.onChange.emit(e);
    }
  }

  onLoadCompleted(fn: () => void) {
    this._onLoadCompleted = fn;
    return this;
  }

  setValue(value) {
    this._value = value;
    this.formControl.setValue(this._value);
  }

  ngOnDestroy() {
    this.subscriptions.forEach(item => {
      item.unsubscribe();
    });
  }

  private busy(value) {
    setTimeout(() => this.loading = value, 0);
  }


}