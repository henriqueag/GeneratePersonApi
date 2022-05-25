import { Component } from '@angular/core';

@Component({
  selector: 'home-content',
  templateUrl: './home-content.component.html'
})
export class HomeContentComponent {

  public title: string = "Imagens de avatares de pessoas";
  public subtitle: string = "Colocado essa imagem apenas para ter algum conteudo aqui"
  public imagem: string = "https://media.istockphoto.com/vectors/cartoon-diverse-people-vector-id521384078";

}
