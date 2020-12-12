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
  @Input() disabled: boolean = false;
  @Input() info: (item: any) => string | Promise<string>;
  @Input() mode: string = 'default';
  @Input() name: any = '';

  infoText: string = '';

  loading: boolean = false;
  loadingMore: boolean = false;
  items = [];

  private _value;
  private propagateChange = (_: any) => { };

  private total: number = 0;
  private offset: number = 0;
  private limit: number = 20;
  private fetchFn: (pagination: string, search?: string) => Observable<Object>;
  private subscriptions = [];
  private _selectFirstOption = false;
  private _onLoadCompleted: (items?: any[]) => void;

  private loadingMoreCallCount = 0;
  private lastLoadingMoreFetchItems = [];

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
    this.lastLoadingMoreFetchItems = [];
    this.loadingMoreCallCount = 0;
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

  fetch(search?: string, clearOnFetch = false) {
    if (this.fetchFn) {
      this.busy(true);
      const pagination = `offset=${this.offset}&limit=${this.limit}`;
      const subscription = this.fetchFn(pagination, search).subscribe(
        (res: any) => {
          this.loading = false;
          this.loadingMore = false;
          const items = res.data.items || [];
          this.lastLoadingMoreFetchItems = items;
          if (clearOnFetch) {
            this.items = [];
          }
          const _items = [...this.items, ...items];
          setTimeout(() => {
            this.items = _items
          }, 0);
          this.busy(false);
          if (this._selectFirstOption && this.items.length > 0) {
            this._value = this.items[0].id;
            this.formControl.setValue(this._value);
          }
          if (this._onLoadCompleted) {
            this._onLoadCompleted(_items);
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
    this._value = e;
    if (this.onChange) {
      this.onChange.emit(e);
    }
    this.infoPromise(e);
  }

  onLoadCompleted(fn: (items?: any[]) => void) {
    this._onLoadCompleted = fn;
    return this;
  }

  setValue(value) {
    this._value = value;
    this.formControl.setValue(this._value);
    return this;
  }

  loadMore() {
    const canLoadMore = (this.loadingMoreCallCount == 0
      || (this.loadingMoreCallCount > 0 && this.lastLoadingMoreFetchItems.length > 0))
      && !this.loadingMore;
    if (canLoadMore) {
      this.loadingMore = true;
      this.fetchNext()
      this.loadingMoreCallCount++;
    }
  }

  getLabel(data: any, key: string) {
    let d = JSON.parse(JSON.stringify(data));
    if (key) {
      key.split('.').forEach(k => {
        d = d[k];
      });
      return d;
    }
    return data.name;
  }

  ngOnDestroy() {
    this.subscriptions.forEach(item => {
      item.unsubscribe();
    });
  }

  private infoPromise(e) {
    if (this.info && this.items && this.items.length) {
      const item = this.items.find(x => x.id == e);
      if (item) {
        Promise.resolve(this.info(item)).then(x => {
          this.infoText = x || '';
        });
      }
    }
  }

  private busy(value) {
    setTimeout(() => {
      this.loading = value
    }, 0);
  }


}