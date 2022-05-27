import { FormBuilder, FormGroup } from '@angular/forms';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { GeneratePersonService } from '../../services/generate-person.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'form-options-generate',
  templateUrl: './form-options-generate.component.html'
})
export class FormOptionsGenerateComponent implements OnInit {

  paramsForm: FormGroup = this.formBuilder.group({
    idades: [''],
    estados: ['Selecione'],
    cidades: [''],
    gerarComPontuacao: [''],
    quantidade: ['1']
  })
  idades: number[] = [];
  estados$: any;
  cidades$: any;
  @Output() response = new EventEmitter();

  constructor(
    private service: GeneratePersonService,
    private http: HttpClient,
    private formBuilder: FormBuilder
  ) { }

  ngOnInit(): void {
    for (let i = 18; i <= 65; i++) {
      this.idades.push(i);
    }
    this.estados$ = this.service.getEstados();
  }

  getSelectCurrentValue() {
    console.log(this.paramsForm.value.estados);

    this.cidades$ = this.service.getCidades(this.paramsForm.value.estados);
  }

  formSubmit() {
    const element_idade = document.getElementById('selectIdade') as HTMLSelectElement;
    const idade = element_idade[element_idade.selectedIndex].innerHTML === "Selecione" ? '' : element_idade[element_idade.selectedIndex].innerHTML;

    const element_estado = document.getElementById('selectEstado') as HTMLSelectElement;
    const estado = element_estado[element_estado.selectedIndex].innerHTML === "Selecione" ? '' : element_estado[element_estado.selectedIndex].innerHTML;

    const element_cidade = document.getElementById('selectCidade') as HTMLSelectElement;
    const cidade = element_cidade[element_cidade.selectedIndex].innerHTML === "Selecione" ? '' : element_cidade[element_cidade.selectedIndex].innerHTML;

    const element_radioSim = document.getElementById('comPonto') as HTMLInputElement;

    const gerarComPonto = element_radioSim.checked === true ? true : false;

    const baseUrl = `http://localhost:5000/api/PersonGenerate/onePerson?idade=${idade}&estado=${estado}&cidade=${cidade}&gerarComPonto=${gerarComPonto}`
    this.http.get<any>(baseUrl).subscribe(x => this.response.emit(x));
  }
}
