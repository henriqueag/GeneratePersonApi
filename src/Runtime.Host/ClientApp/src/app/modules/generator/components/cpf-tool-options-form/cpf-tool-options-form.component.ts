import { Component, EventEmitter, Input, Output, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IBrazilianState } from '../../models/brazilian-state';

@Component({
  selector: 'dg-cpf-tool-options-form',
  templateUrl: './cpf-tool-options-form.component.html',
  styleUrls: ['./cpf-tool-options-form.component.scss']
})
export class CpfToolOptionsFormComponent implements OnInit {
  @Input() brazilianStates: IBrazilianState[] | null
  @Input() isLoading: boolean | null
  @Output() chosenOptions = new EventEmitter<any>()

  isValidForm = true
  defaultValue = 'Selecione um estado'
  optionsForm: FormGroup

  constructor(private _formBuilder: FormBuilder) {}

  ngOnInit(): void {
    this.optionsForm = this._formBuilder.group({
      withMask: [true],
      state: ['', [Validators.required]]
    })

    this.optionsForm.controls['state'].setValue(null, { onlySelf: true })
  }

  onChosenOptions() {
    if (!this.optionsForm.valid) {
      this.isValidForm = false
      return
    }

    this.chosenOptions.next(this.getOptions())
  }

  private getOptions() {
    this.isValidForm = true

    const withMask = this.optionsForm.controls['withMask'].value
    const state = this.optionsForm.controls['state'].value

    var result = {
      withMask: withMask,
      state: state
    }

    return result;
  }
}