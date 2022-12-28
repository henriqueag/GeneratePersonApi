import { Component, Input } from '@angular/core';
import { INavbar } from './navbar.component.d'

@Component({
  selector: 'dg-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent {
  @Input() navbarItem: INavbar
}
