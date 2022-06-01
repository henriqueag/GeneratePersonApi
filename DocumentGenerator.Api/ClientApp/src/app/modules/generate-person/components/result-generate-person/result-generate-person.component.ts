import { Component, Input } from '@angular/core';
import { GeneratePerson } from '../../models/generate-person.model';

@Component({
    selector: 'result-generate-person',
    templateUrl: './result-generate-person.component.html'
})
export class ResultGeneratePersonComponent {

    @Input() response: GeneratePerson;


}
