import { FormBuilder, FormGroup } from '@angular/forms';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { GeneratePersonApi } from 'src/app/modules/generate-person/apis/generate-person.api';
import { DropdownService } from '../../services/dropdown.service';
import { Observable } from 'rxjs';

@Component({
    selector: 'form-options-generate',
    templateUrl: './form-options-generate.component.html'
})
export class FormOptionsGenerateComponent implements OnInit {

    paramsForm: FormGroup = this.formBuilder.group({
        idades: ['Selecione'],
        estados: ['Selecione'],
        cidades: ['Selecione'],
        gerarComMascara: [true],
        quantidade: ['1']
    })

    idades: number[];
    gerarComMascara: any[];

    estados$: Observable<any>;
    cidades$: Observable<any>;

    @Output() response = new EventEmitter();

    constructor(
        private service: GeneratePersonApi,
        private dropdownService: DropdownService,
        private formBuilder: FormBuilder
    ) { }

    ngOnInit(): void {
        this.idades = this.dropdownService.getIdades();
        this.gerarComMascara = this.dropdownService.getGerarComPonto();
        this.estados$ = this.service.getEstados();
    }

    getSelectCurrentValue() {
        this.cidades$ = this.service.getCidades(this.paramsForm.value.estados);
    }

    formSubmit() {
        const params = {
            quantidade: this.paramsForm.value.quantidade,
            idade: this.paramsForm.value.idades === 'Selecione' ? "" : this.paramsForm.value.idades,
            estadoBR_sigla: this.paramsForm.value.estados === 'Selecione' ? "" : this.paramsForm.value.estados,
            cidade: this.paramsForm.value.cidades === 'Selecione' ? "" : this.paramsForm.value.cidades,
            gerarComMascara: this.paramsForm.value.gerarComMascara,
        }
        this.service.getPersons(params).subscribe(data => this.response.emit(data));
    }
}
