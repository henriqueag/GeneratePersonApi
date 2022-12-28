import { PersonGeneratorComponent } from './pages/person-generator/person-generator.component';
import { RgGeneratorComponent } from './pages/rg-generator/rg-generator.component';
import { CnpjGeneratorComponent } from './pages/cnpj-generator/cnpj-generator.component';
import { CpfGeneratorComponent } from './pages/cpf-generator/cpf-generator.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'cpf',
    component: CpfGeneratorComponent
  },
  {
    path: 'cnpj',
    component: CnpjGeneratorComponent
  },
  {
    path: 'rg',
    component: RgGeneratorComponent
  },
  {
    path: 'person',
    component: PersonGeneratorComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GeneratorRoutingModule { }
