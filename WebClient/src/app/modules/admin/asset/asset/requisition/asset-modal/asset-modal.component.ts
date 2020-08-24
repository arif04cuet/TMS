import { Component, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BaseComponent } from 'src/app/shared/base.component';

@Component({
  selector: 'app-asset-modal',
  templateUrl: './asset-modal.component.html'
})
export class AssetModalComponent extends BaseComponent {

  @Input() data: any = {};
  cloneData: any = {};
  send = false;

  constructor(
    private activatedRoute: ActivatedRoute
  ) {
    super();
  }

  ngOnInit() {
    this.cloneData = JSON.parse(JSON.stringify(this.data));
    this.snapshot(this.activatedRoute.snapshot);
  }

  ngOnDestroy() {
    if(this.send) {
      this.data = JSON.parse(JSON.stringify(this.cloneData));
    }
  }

}
