import { IPersonGeneratorResponse } from './../../models/person-generator-response.d';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'dg-person-generator-result-form',
  templateUrl: './person-generator-result-form.component.html',
  styleUrls: ['./person-generator-result-form.component.scss']
})
export class PersonGeneratorResultFormComponent implements OnInit {
  personResult = {
    "name": "Enrico Ian Novaes",
    "cpf": "711.237.102-36",
    "rg": "45.215.608-7",
    "birthDate": "2002-08-29T00:00:00",
    "age": 20,
    "phone": "(68) 99831-4057",
    "email": "marliceciliamarcia@hotmail.com",
    "address": {
      "street": "Rua Botafogo",
      "district": "Defesa Civil",
      "complement": "",
      "city": "Rio Branco",
      "cep": "69921-848",
      "state": "AC",
      "ddd": "68"
    }
  }

  constructor() { }

  ngOnInit() {
  }

}
