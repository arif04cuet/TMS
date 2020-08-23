import { Component, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BaseComponent } from 'src/app/shared/base.component';

@Component({
  selector: 'app-asset-modal',
  templateUrl: './asset-modal.component.html'
})
export class AssetModalComponent extends BaseComponent {

  @Input() data: any = {};

  constructor(
    private activatedRoute: ActivatedRoute
  ) {
    super();
  }

  ngOnInit() {
    this.snapshot(this.activatedRoute.snapshot);
  }

}
