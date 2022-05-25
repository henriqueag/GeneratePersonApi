import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GeneratePersonService {

  constructor(private httpClient: HttpClient) { }

  getEstados(): Observable<any> {
    const baseURL = "http://localhost:5000/api/DocGenerate/estados";
    return this.httpClient.get(baseURL);
  }

  getCidades(estado: number): Observable<any> {
    const baseURL = `http://localhost:5000/api/DocGenerate/cidades?estadosBR=${estado}`;
    return this.httpClient.get(baseURL);
  }
}
