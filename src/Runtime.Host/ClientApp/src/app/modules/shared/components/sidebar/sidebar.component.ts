import { Component, Input } from '@angular/core';
import { Sidebar } from './sidebar.component.d';

@Component({
  selector: 'dg-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})

export class SidebarComponent {
  @Input() sidebarItems: Sidebar[]
}