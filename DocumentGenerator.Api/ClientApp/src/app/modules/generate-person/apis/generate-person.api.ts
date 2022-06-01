import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { GeneratePerson } from '../models/generate-person.model';

@Injectable({
    providedIn: 'root'
})
export class GeneratePersonApi {

    constructor(private httpClient: HttpClient) { }

    getEstados() {
        return this.httpClient.get<any>(`${environment.apiHost}/api/v1/Endereco/estados`);
    }

    getCidades(estado_sigla: string) {
        return this.httpClient.get<any>(`${environment.apiHost}/api/v1/Endereco/cidades?estadosBR_sigla=${estado_sigla}`);
    }

    getPersons(params: any) {
        let url: string;
        if (params.quantidade > 1) {
            url = `${environment.apiHost}/api/v1/PersonGenerate/listPerson?quantidade=${params.quantidade}&idade=${params.idade}&estadoBR_sigla=${params.estadoBR_sigla}&cidade=${params.cidade}&gerarComMascara=${params.gerarComMascara}`;
            return this.httpClient.get<GeneratePerson>(url);
        }
        url = `${environment.apiHost}/api/v1/PersonGenerate/onePerson?idade=${params.idade}&estadoBR_sigla=${params.estadoBR_sigla}&cidade=${params.cidade}&gerarComMascara=${params.gerarComMascara}`;
        return this.httpClient.get<GeneratePerson>(url);
    }
}
