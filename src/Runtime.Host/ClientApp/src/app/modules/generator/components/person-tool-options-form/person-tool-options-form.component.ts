import { IBrazilianCities } from './../../models/brazilian-cities.d';
import { IBrazilianState } from './../../models/brazilian-state.d';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'dg-person-tool-options-form',
  templateUrl: './person-tool-options-form.component.html',
  styleUrls: ['./person-tool-options-form.component.scss']
})
export class PersonToolOptionsFormComponent implements OnInit {
  @Input() isLoading: boolean | null
  @Input() brazilianStates: IBrazilianState[] | null
  @Input() brazilianCities: IBrazilianCities | null
  @Output() chosenOptions = new EventEmitter<any>()
  @Output() stateChange = new EventEmitter<any>()

  optionsForm: FormGroup
  defaultStateValue = 'Selecione um estado'
  defaultCityValue = 'Selecione uma cidade'

  constructor(private _formBuilder: FormBuilder) { }

  ngOnInit() {
    this.optionsForm = this._formBuilder.group({
      minAge: [18],
      maxAge: [89],
      quantity: [1],
      state: [''],
      cityName: ['']
    })

    this.optionsForm.controls['state'].setValue(null, { onlySelf: true })
    this.optionsForm.controls['cityName'].setValue(null, { onlySelf: true })
  }

  onChosenOptions() {
    this.chosenOptions.emit(this.optionsForm.value)
  }

  onStateChange() {
    this.stateChange.emit(this.optionsForm.controls['state'].value)
  }
}