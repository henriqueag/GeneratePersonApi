import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class DropdownService {

    getGerarComPonto() {
        return [
            { value: true, displayName: "Sim" },
            { value: false, displayName: "Não" }
        ]
    }

    getIdades() {
        let idades: number[] = [];
        for (let i = 18; i < 65; i++) {
            idades.push(i);
        }
        return idades;
    }
}
