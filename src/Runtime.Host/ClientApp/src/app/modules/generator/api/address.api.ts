import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { IBrazilianState } from '../models/brazilian-state';
import { Injectable } from '@angular/core';
import { IBrazilianCities } from '../models/brazilian-cities';
import { IAddressRequest } from '../models/address-request';

const ROUTE = `${environment.coreApiUrl}/api/address`

@Injectable()
export class AddressApi {
  constructor(private _httpClient: HttpClient) { }

  getBrazilianStates() {
    return this._httpClient.get<IBrazilianState[]>(`${ROUTE}/brazilian-states`)
  }

  getBrazilianCities(abbreviationState: string) {
    const query = {
      abbreviationState: abbreviationState
    }

    return this._httpClient.get<IBrazilianCities>(`${ROUTE}/brazilian-cities`, { params: query })
  }

  postBrazilianAddress(body: IAddressRequest) {
    return this._httpClient.post(`${ROUTE}/brazilian-address`, body)
  }
}
