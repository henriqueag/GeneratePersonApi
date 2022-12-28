import { DocumentApi } from './../../api/document.api';
import { BehaviorSubject, catchError, delay, map, Observable } from 'rxjs';
import { AddressApi } from './../../api/address.api';
import { Component, OnInit } from '@angular/core';
import { IBrazilianState } from '../../models/brazilian-state';

@Component({
  selector: 'dg-cpf-generator',
  templateUrl: './cpf-generator.component.html',
  styleUrls: ['./cpf-generator.component.scss']
})
export class CpfGeneratorComponent implements OnInit {
  brazilianStates$: Observable<IBrazilianState[]>
  createdCpf$: Promise<string>
  isLoading$ = new BehaviorSubject<boolean>(false)
  canShowCopyToClipboard$ = new BehaviorSubject<boolean>(false)

  constructor(
    private _api: AddressApi,
    private _documentApi: DocumentApi
  ) { }

  ngOnInit(): void {
    this.brazilianStates$ = this._api.getBrazilianStates()
  }

  getChosenOptions(options: any) {
    this.createdCpf$ = new Promise<string>((resolve, reject) => {
      this.isLoading$.next(true)

      this._documentApi.getCpf(options.state, options.withMask)
        .pipe(
          map(value => value.cpf),
          catchError(this.onSubmitError(reject))
        )
        .subscribe(this.onSubmitNext(resolve))
    })
  }

  private onSubmitNext = (resolve: any) => (cpf: string) => {
    this.isLoading$.next(false)
    this.canShowCopyToClipboard$.next(true)

    resolve(cpf)
  }

  private onSubmitError = (reject) => (err, caught) => {
    this.isLoading$.next(false)
    this.canShowCopyToClipboard$.next(false)

    reject(err)
    throw caught
  }
}