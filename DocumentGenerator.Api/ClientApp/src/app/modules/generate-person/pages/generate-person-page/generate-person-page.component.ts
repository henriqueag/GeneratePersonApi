import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'generate-person-page',
  templateUrl: './generate-person-page.component.html'
})
export class GeneratePersonPageComponent implements OnInit {

  resultText: string;

  constructor() { }

  ngOnInit(): void {
  }

  getEvent(event: any) {
    this.resultText = JSON.stringify(event, null, 4);
  }

}
