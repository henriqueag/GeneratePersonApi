import { Component } from '@angular/core';
import { BehaviorSubject, catchError, map } from 'rxjs';
import { DocumentApi } from '../../api/document.api';

@Component({
  selector: 'dg-rg-generator',
  templateUrl: './rg-generator.component.html',
  styleUrls: ['./rg-generator.component.scss']
})
export class RgGeneratorComponent{
  createdRg$: Promise<string>
  isLoading$ = new BehaviorSubject<boolean>(false)
  canShowCopyToClipboard$ = new BehaviorSubject<boolean>(false)

  constructor(private _documentApi: DocumentApi) { }

  getChosenOptions(options: any) {
    this.createdRg$ = new Promise<string>((resolve, reject) => {
      this.isLoading$.next(true)

      this._documentApi.getRg(options.withMask)
        .pipe(
          map(value => value.rg),
          catchError(this.onSubmitError(reject))
        )
        .subscribe(this.onSubmitNext(resolve))
    })
  }

  private onSubmitNext = (resolve: any) => (rg: string) => {
    this.isLoading$.next(false)
    this.canShowCopyToClipboard$.next(true)

    resolve(rg)
  }

  private onSubmitError = (reject) => (err, caught) => {
    this.isLoading$.next(false)
    this.canShowCopyToClipboard$.next(false)

    reject(err)
    throw caught
  }
}