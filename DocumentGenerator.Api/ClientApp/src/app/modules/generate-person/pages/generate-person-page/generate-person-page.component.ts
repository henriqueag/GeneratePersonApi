import { Component } from '@angular/core';
import { GeneratePerson } from '../../models/generate-person.model';

@Component({
    selector: 'generate-person-page',
    templateUrl: './generate-person-page.component.html'
})
export class GeneratePersonPageComponent {

    result: GeneratePerson;

    getEvent(event: any) {
        this.result = event as GeneratePerson;
    }

}
