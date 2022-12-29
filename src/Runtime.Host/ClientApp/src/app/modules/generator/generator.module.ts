import { AddressApi } from './api/address.api';
import { CnpjGeneratorComponent } from './pages/cnpj-generator/cnpj-generator.component';
import { CnpjToolOptionsComponent } from './components/cnpj-tool-options-form/cnpj-tool-options-form.component';
import { CommonModule } from '@angular/common';
import { CpfGeneratorComponent } from './pages/cpf-generator/cpf-generator.component';
import { CpfToolOptionsFormComponent } from './components/cpf-tool-options-form/cpf-tool-options-form.component';
import { DocumentApi } from './api/document.api';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { GeneratorRoutingModule } from './generator-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { PersonGeneratorComponent } from './pages/person-generator/person-generator.component';
import { PersonToolOptionsFormComponent } from './components/person-tool-options-form/person-tool-options-form.component';
import { RgGeneratorComponent } from './pages/rg-generator/rg-generator.component';
import { RgToolOptionsComponent } from './components/rg-tool-options-form/rg-tool-options-form.component';
import { SharedModule } from './../shared/shared.module';
import { PersonApi } from './api/person.api';
import { PersonGeneratorResultFormComponent } from './components/person-generator-result-form/person-generator-result-form.component';

@NgModule({
  imports: [
    CommonModule,
    GeneratorRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    SharedModule
  ],
  declarations: [
    CpfGeneratorComponent,
    CnpjGeneratorComponent,
    RgGeneratorComponent,
    PersonGeneratorComponent,
    CpfToolOptionsFormComponent,
    CnpjToolOptionsComponent,
    RgToolOptionsComponent,
    PersonToolOptionsFormComponent,
    PersonGeneratorResultFormComponent
  ],
  providers: [
    AddressApi,
    DocumentApi,
    PersonApi
  ]
})
export class GeneratorModule { }
