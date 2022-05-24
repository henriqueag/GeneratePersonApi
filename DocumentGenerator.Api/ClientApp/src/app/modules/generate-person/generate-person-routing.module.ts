import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GeneratePersonPageComponent } from './pages/generate-person-page/generate-person-page.component';

const routes: Routes = [
  { path: "", component: GeneratePersonPageComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GeneratePersonRoutingModule { }
