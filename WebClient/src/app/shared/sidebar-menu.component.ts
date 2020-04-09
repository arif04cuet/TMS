import { Component, Input, NgModule } from '@angular/core';
import { SharedModule } from './shared.module';
import { NzMenuModule, NgZorroAntdModule, NzMenuBaseService, NzMenuService } from 'ng-zorro-antd';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-sidebar-menu',
  template:  `
    <ng-container *ngFor="let m of menus">
      <app-sidebar-menu-item [nav]="m"></app-sidebar-menu-item>
    </ng-container>
  `
})
export class SidebarMenuComponent {

  @Input() menus = []

  constructor() {
  }

}

@Component({
    selector: 'app-sidebar-menu-item',
    template:  `
      <ng-container *ngIf="nav && nav.childs">
        <li nz-submenu [nzTitle]="nav.title">
          <ul>
            <app-sidebar-menu-item [nav]="nav.childs"></app-sidebar-menu-item>
          </ul>
        </li>
      </ng-container>
      <li nz-menu-item nzMatchRouter *ngIf="!nav.childs">
        <a [routerLink]="nav.route">{{nav.title}}</a>
      </li>
    `
  })
export class SidebarMenuItemComponent {

    @Input() nav: any = {};

    constructor() {
    }

}

@NgModule({
  imports: [
    SharedModule,
    NzMenuModule,
    NgZorroAntdModule,
    CommonModule,
    RouterModule
  ],
  declarations: [
    SidebarMenuItemComponent,
    SidebarMenuComponent
  ],
  exports: [
    SidebarMenuItemComponent,
    SidebarMenuComponent
  ],
  providers: [
    NzMenuBaseService,
    NzMenuService
  ]
})
export class SidebarMenuModule {
  
}