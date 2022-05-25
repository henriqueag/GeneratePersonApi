import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'result-generate-person',
  templateUrl: './result-generate-person.component.html'
})
export class ResultGeneratePersonComponent implements OnInit {

  @Input() response: string;

  constructor() { }

  ngOnInit(): void {
  }

}
