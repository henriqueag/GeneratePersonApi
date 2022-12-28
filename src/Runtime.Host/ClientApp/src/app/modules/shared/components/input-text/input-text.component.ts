import { Component, Input, EventEmitter, Output, forwardRef, ViewChild, ElementRef } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';

@Component({
  selector: 'dg-input-text',
  templateUrl: './input-text.component.html',
  styleUrls: ['./input-text.component.scss'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => InputTextComponent),
      multi: true
    }
  ]
})
export class InputTextComponent implements ControlValueAccessor {
  @Input() label: string = ''
  @Input() minLength: number = 0
  @Input() maxLength: number = 99_999
  @Input() disabled: boolean = false
  @Input() readOnly: boolean = false
  @Input() required: boolean = false
  @Input() name: string = ''
  @Input() placeholder: string = ''
  @Input() showCopyToClipboard: boolean | null = false

  @Output('dg-focus') focus = new EventEmitter<any>()
  @Output('dg-blur') blur = new EventEmitter<any>()
  @Output('dg-change') change = new EventEmitter<any>()
  @Output('dg-keydown') keydown = new EventEmitter<any>()

  @ViewChild('inputText') inputText: ElementRef

  onFocus = () => this.focus.emit()
  onBlur = () => this.blur.emit()
  onChangeModel = () => this.change.emit()
  onKeydown = () => this.keydown.emit()


  private _innerValue: any;

  get value() {
    return this._innerValue
  }

  set value(val: any) {
    if (val !== this._innerValue) {
      this._innerValue = val
      this._onChange(val)
    }
  }

  private _onChange = (_:any) => undefined
  private _onTouched = (_: any) => undefined

  writeValue(value: any): void {
    this.value = value
  }

  registerOnChange(fn: any): void {
    this._onChange = fn
  }

  registerOnTouched(fn: any): void {
    this._onTouched = fn
  }

  setDisabledState?(isDisabled: boolean): void {
    this.disabled = isDisabled
  }

  copyToClipboard(input: HTMLInputElement) {
    input.select()
    input.setSelectionRange(0, 99999)

    navigator.clipboard.writeText(input.value)

    console.log(`Valor copiado para area de transferencia: ${input.value}`)
  }
}