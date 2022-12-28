import { Component, EventEmitter, Output, Input } from '@angular/core';

@Component({
  selector: 'dg-button',
  templateUrl: './button.component.html',
  styleUrls: ['./button.component.scss']
})
export class ButtonComponent {
  @Input() className: string = 'primary'
  @Input() loading: boolean | null
  @Input() disabled: boolean | null
  @Input() icon: string
  @Input() type: string = 'default'
  @Input() label: string

  @Output('dg-click') click: EventEmitter<any> = new EventEmitter()

  buttonClick = () => this.click.emit()
}