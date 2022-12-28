import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './components/navbar/navbar.component';
import { NgModule } from '@angular/core';
import { MenuService } from './service/menu.service';
import { ButtonComponent } from './components/button/button.component';
import { InputTextComponent } from './components/input-text/input-text.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule
  ],
  declarations: [
    NavbarComponent,
    SidebarComponent,
    ButtonComponent,
    InputTextComponent
  ],
  exports: [
    NavbarComponent,
    SidebarComponent,
    ButtonComponent,
    InputTextComponent
  ],
  providers: [
    MenuService
  ]
})
export class SharedModule { }
