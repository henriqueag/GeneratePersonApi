import { Component } from '@angular/core';
import { BehaviorSubject, catchError, map } from 'rxjs';
import { DocumentApi } from '../../api/document.api';

@Component({
  selector: 'dg-cnpj-generator',
  templateUrl: './cnpj-generator.component.html',
  styleUrls: ['./cnpj-generator.component.scss']
})
export class CnpjGeneratorComponent {
  createdCnpj$: Promise<string>
  isLoading$ = new BehaviorSubject<boolean>(false)
  canShowCopyToClipboard$ = new BehaviorSubject<boolean>(false)

  constructor(private _documentApi: DocumentApi) { }

  getChosenOptions(options: any) {
    this.createdCnpj$ = new Promise<string>((resolve, reject) => {
      this.isLoading$.next(true)

      this._documentApi.getCnpj(options.withMask)
        .pipe(
          map(value => value.cnpj),
          catchError(this.onSubmitError(reject))
        )
        .subscribe(this.onSubmitNext(resolve))
    })
  }

  private onSubmitNext = (resolve: any) => (cnpj: string) => {
    this.isLoading$.next(false)
    this.canShowCopyToClipboard$.next(true)

    resolve(cnpj)
  }

  private onSubmitError = (reject) => (err, caught) => {
    this.isLoading$.next(false)
    this.canShowCopyToClipboard$.next(false)

    reject(err)
    throw caught
  }
}