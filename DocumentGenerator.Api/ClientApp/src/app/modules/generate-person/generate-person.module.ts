import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { GeneratePersonRoutingModule } from './generate-person-routing.module';
import { GeneratePersonPageComponent } from './pages/generate-person-page/generate-person-page.component';
import { FormOptionsGenerateComponent } from './components/form-options-generate/form-options-generate.component';
import { ResultGeneratePersonComponent } from './components/result-generate-person/result-generate-person.component';


@NgModule({
  declarations: [
    GeneratePersonPageComponent,
    FormOptionsGenerateComponent,
    ResultGeneratePersonComponent
  ],
  imports: [
    CommonModule,
    GeneratePersonRoutingModule
  ]
})
export class GeneratePersonModule { }
