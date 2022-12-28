import { Sidebar as ISidebar } from './modules/shared/components/sidebar/sidebar.component.d';
import { INavbar } from './modules/shared/components/navbar/navbar.component.d';
import { Component, OnInit } from '@angular/core';
import { MenuService } from './modules/shared/service/menu.service';

@Component({
  selector: 'dg-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  navbar: INavbar;
  sidebarItems: ISidebar[];

  constructor(private _menuService: MenuService) { }

  ngOnInit(): void {
    this.navbar = this._menuService.getNavbarItems();
    this.sidebarItems = this._menuService.getSidebarItems();
  }
}