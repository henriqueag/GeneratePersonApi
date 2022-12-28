import { SharedModule } from './../shared/shared.module';
import { DocumentApi } from './api/document.api';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CpfToolOptionsFormComponent } from './components/cpf-tool-options-form/cpf-tool-options-form.component';
import { CnpjGeneratorComponent } from './pages/cnpj-generator/cnpj-generator.component';
import { CommonModule } from '@angular/common';
import { CpfGeneratorComponent } from './pages/cpf-generator/cpf-generator.component';
import { GeneratorRoutingModule } from './generator-routing.module';
import { NgModule } from '@angular/core';
import { PersonGeneratorComponent } from './pages/person-generator/person-generator.component';
import { RgGeneratorComponent } from './pages/rg-generator/rg-generator.component';
import { HttpClientModule } from '@angular/common/http';
import { AddressApi } from './api/address.api';
import { CnpjToolOptionsComponent } from './components/cnpj-tool-options-form/cnpj-tool-options-form.component';
import { RgToolOptionsComponent } from './components/rg-tool-options-form/rg-tool-options-form.component';

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
    RgToolOptionsComponent
  ],
  providers: [
    AddressApi,
    DocumentApi
  ]
})
export class GeneratorModule { }
