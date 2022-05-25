import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StartRoutingModule } from './start-routing.module';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { HomeContentComponent } from './components/home-content/home-content.component';

@NgModule({
  declarations: [
    HomePageComponent,
    HomeContentComponent
  ],
  imports: [
    CommonModule,
    StartRoutingModule
  ]
})
export class StartModule { }
