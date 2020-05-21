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
  @Input() info: (item: any) => string | Promise<string>;
  @Input() mode: string = 'default';

  infoText: string = '';

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
          this.loading = false;
          const items = res.data.items || [];
          this.items = [...this.items, ...items];
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
    return this;
  }

  selectFirstOption() {
    this._selectFirstOption = true;
    return this;
  }

  onValueChange(e) {
    if (this.onChange) {
      this.onChange.emit(e);
    }
    if (this.info) {
      const item = this.items.find(x => x.id == e);
      Promise.resolve(this.info(item)).then(x => {
        this.infoText = x || '';
      })
    }
  }

  onLoadCompleted(fn: () => void) {
    this._onLoadCompleted = fn;
    return this;
  }

  setValue(value) {
    this._value = value;
    this.formControl.setValue(this._value);
    return this;
  }

  loadMore() {
    this.loading = true;
    this.fetchNext()
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