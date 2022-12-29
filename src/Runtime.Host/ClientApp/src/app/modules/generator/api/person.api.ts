import { IPersonGeneratorRequest } from './../models/person-generator-request.d';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IPersonGeneratorResponse } from '../models/person-generator-response';

const ROUTE = `${environment.coreApiUrl}/api/person`

@Injectable()
export class PersonApi {
  constructor(private _httpClient: HttpClient) { }

  getOne(data: IPersonGeneratorRequest) {
    const body = this.getBody(data)
    return this._httpClient.post<IPersonGeneratorResponse>(`${ROUTE}/one-person`, body)
  }

  getList(data: IPersonGeneratorRequest) {
    const body = this.getBody(data)
    return this._httpClient.post<IPersonGeneratorResponse[]>(`${ROUTE}/list-person/${data.quantity}`, body)
  }

  private getBody(data: IPersonGeneratorRequest) {
    return {
      minAge: data.minAge,
      maxAge: data.maxAge,
      state: data.state,
      cityName: data.cityName
    }
  }
}