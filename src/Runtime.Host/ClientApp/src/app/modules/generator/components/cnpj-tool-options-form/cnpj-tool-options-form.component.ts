import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'dg-cnpj-tool-options-form',
  templateUrl: './cnpj-tool-options-form.component.html',
  styleUrls: ['./cnpj-tool-options-form.component.scss']
})
export class CnpjToolOptionsComponent implements OnInit {

  @Input() isLoading: boolean | null
  @Output() chosenOptions = new EventEmitter<any>()

  optionsForm: FormGroup

  constructor(private _formBuilder: FormBuilder) {}

  ngOnInit(): void {
    this.optionsForm = this._formBuilder.group({
      withMask: [true]
    })
  }

  onChosenOptions() {
    this.chosenOptions.emit(this.getOptions())
  }

  private getOptions() {
    const withMask = this.optionsForm.controls['withMask'].value

    var result = {
      withMask: withMask
    }

    return result;
  }
}