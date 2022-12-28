import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

const ROUTE = `${environment.coreApiUrl}/api/document`

@Injectable()
export class DocumentApi {
  constructor(private _httpClient: HttpClient) { }

  getCpf(state: string, withMask: boolean) {
    const query = {
      abbreviationState: state,
      withMask: withMask
    }

    return this._httpClient.get<any>(`${ROUTE}/generate-cpf`, { params: query })
  }

  getCnpj(withMask: string) {
    const query = {
      withMask: withMask
    }

    return this._httpClient.get<any>(`${ROUTE}/generate-cnpj`, { params: query })
  }

  getRg(withMask: string) {
    const query = {
      withMask: withMask
    }

    return this._httpClient.get<any>(`${ROUTE}/generate-rg`, { params: query })
  }
}
