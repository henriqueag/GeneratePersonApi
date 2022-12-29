import { IPersonGeneratorRequest } from './../../models/person-generator-request.d';
import { AddressApi } from './../../api/address.api';
import { BehaviorSubject, Observable, catchError } from 'rxjs';
import { Component, OnInit } from '@angular/core';
import { IBrazilianState } from '../../models/brazilian-state';
import { IBrazilianCities } from '../../models/brazilian-cities';
import { PersonApi } from '../../api/person.api';
import { IPersonGeneratorResponse } from '../../models/person-generator-response';

@Component({
  selector: 'dg-person-generator',
  templateUrl: './person-generator.component.html',
  styleUrls: ['./person-generator.component.scss']
})
export class PersonGeneratorComponent implements OnInit {
  personResult$: Promise<IPersonGeneratorResponse | IPersonGeneratorResponse[]>
  isLoading$ = new BehaviorSubject<boolean>(false)
  brazilianStates$: Observable<IBrazilianState[]>
  brazilianCities$: Observable<IBrazilianCities>

  constructor(
    private _personApi: PersonApi,
    private _addressApi: AddressApi
  ) { }

  ngOnInit(): void {
    this.brazilianStates$ = this._addressApi.getBrazilianStates()
  }

  onGeneratePerson(value: IPersonGeneratorRequest) {
    this.personResult$ = new Promise((resolve, reject) => {
      this.isLoading$.next(true)

      if (value.quantity == 1) {
        this._personApi.getOne(value)
          .pipe(catchError(this.onSubmitError(reject)))
          .subscribe(this.onSubmitNext(resolve))
      } else {
        this._personApi.getList(value)
          .pipe(catchError(this.onSubmitError(reject)))
          .subscribe(this.onSubmitNext(resolve))
      }
    })
  }

  onCurrentState(value: string) {
    if (value) {
      this.brazilianCities$ = this._addressApi.getBrazilianCities(value)
    }
  }

  private onSubmitNext = (resolve: any) => (data: any) => {
    this.isLoading$.next(false)
    resolve(data)
  }

  private onSubmitError = (reject) => (err, caugth) => {
    this.isLoading$.next(false)

    reject(err)
    throw caugth
  }
}