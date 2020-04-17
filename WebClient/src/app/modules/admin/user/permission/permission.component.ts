import { Component, Input } from '@angular/core';
import { BaseComponent } from 'src/app/shared/base.component';
import { AuthService } from 'src/services/auth.service';
import { NzTreeNodeOptions, NzFormatEmitEvent } from 'ng-zorro-antd';
import { PermissionHttpService } from 'src/services/http/permission-http.service';
import { RoleHttpService } from 'src/services/http/role-http.service';
import { ActivatedRoute } from '@angular/router';
import { UserHttpService } from 'src/services/http/user-http.service';
import { MESSAGE_KEY } from 'src/constants/message-key.constant';

@Component({
  selector: 'app-permission',
  templateUrl: './permission.component.html',
  styleUrls: ['./permission.component.scss']
})
export class PermissionComponent extends BaseComponent {

  loading: boolean = false;
  nodes: NzTreeNodeOptions[] = []
  defaultCheckedKeys = [];
  defaultSelectedKeys = [];
  title;
  @Input() purpose;

  private userId;
  private _snapshot;
  private service;
  private cancelUrl;

  // could be roleId, or userId. depends on route
  private id;


  constructor(
    private roleHttpService: RoleHttpService,
    private userHttpService: UserHttpService,
    private permissionHttpService: PermissionHttpService,
    private authService: AuthService,
    private activatedRoute: ActivatedRoute
  ) {
    super();
  }

  async ngOnInit() {
    this._snapshot = this.activatedRoute.snapshot;
    this.snapshot(this._snapshot);
    this.id = this._snapshot.queryParams['id'] || this._snapshot.params['id'];
    this.userId = this.authService.getLoggedInUserId();
    await this.init();
    this.get();
  }

  get() {
    if (this.service) {
      this.subscribe(this.service.getPermissions(this.id),
        (res: any) => {
          this.nodes = this.transformTreeData(res);
          this.loading = false;
        },
        (err: any) => {
          this.loading = false;
        }
      );
    }
  }

  assign() {
    if (this.service && this.id && this.nodes && this.nodes.length > 0) {
      const permissionIds = [];
      this.getPermissionIds(this.nodes, permissionIds);
      if (permissionIds.length > 0) {
        this.subscribe(this.service.assignPermissions(this.id, permissionIds),
          (res: any) => {
            this.success(MESSAGE_KEY.SUCCESSFULLY_UPDATED);
          },
          (err: any) => {

          }
        );
      }
    }
  }

  nzEvent(event: NzFormatEmitEvent): void {
    this.log(event);
  }

  cancel() {
    if (this.snapshot && this._snapshot.data) {
      if (this._snapshot.data.name == 'role_permissions') {
        this.goTo('/admin/roles');
      }
      else if (this._snapshot.data.name == 'user_permissions') {
        this.goTo('/admin/users');
      }
    }
  }

  private async init() {
    if (this.snapshot && this._snapshot.data) {
      if (this.purpose == 'role') {
        this.service = this.roleHttpService;
      }
      else if (this.purpose == 'user') {
        this.service = this.userHttpService;
      }
    }
  }

  private transformTreeData(res) {
    const data = [];
    const checked = [];
    res.data.items.forEach(m => {
      const module = {
        title: m.module.name,
        key: `${m.module.id}-${m.module.name.toLowerCase().trim()}`,
        children: []
      }
      data.push(module);
      m.groups.forEach(g => {
        const group = {
          title: g.group.name,
          key: `${g.group.id}-${g.group.name.toLowerCase().trim()}`,
          children: []
        }
        module.children.push(group);
        g.permissions.forEach(p => {
          const key = `permission-${p.id}`;
          const permission = {
            title: p.name,
            key: key
          }
          group.children.push(permission);
          if (p.granted) {
            checked.push(key)
          }
        });
      });
    });
    this.defaultCheckedKeys = checked;
    return data;
  }

  private getPermissionIds(arr, keys) {
    if (arr && arr.length > 0) {
      for (let i = 0; i < arr.length; i++) {
        const item = arr[i];
        if (item.checked && item.key.startsWith('permission-')) {
          keys.push(Number(item.key.replace('permission-', '')));
        }
        if (item.children && item.children.length > 0) {
          this.getPermissionIds(item.children, keys);
        }
      }
    }
  }

}
