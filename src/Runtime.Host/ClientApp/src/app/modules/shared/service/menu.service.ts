import { INavbar } from '../components/navbar/navbar.component.d';
import { Injectable } from '@angular/core';
import { Sidebar } from './../components/sidebar/sidebar.component.d';

@Injectable()
export class MenuService {
  getNavbarItems(): INavbar {
    return {
      logoImg: './assets/images/logo.png',
      logoAltText: 'Logo do aplicativo',
      logoTitle: 'For Devs',
      logoDescription: 'By Henrique Aguiar',
      navbarItems: [
        {
          icon: 'fa-brands fa-github',
          link: 'https://github.com/henriqueag?tab=repositories'
        },
        {
          icon: 'fa-brands fa-linkedin',
          link: 'https://www.linkedin.com/in/henriquesaguiar/'
        },
        {
          icon: 'fa-brands fa-instagram',
          link: 'https://www.instagram.com/henrique.aguiar2'
        }
      ]
    }
  }

  getSidebarItems(): Sidebar[] {
    return [
      {
        icon: 'fa-solid fa-database',
        label: 'Gerador de CPF',
        link: '/generator/cpf'
      },
      {
        icon: 'fa-solid fa-database',
        label: 'Gerador de CNPJ',
        link: '/generator/cnpj'
      },
      {
        icon: 'fa-solid fa-database',
        label: 'Gerador de RG',
        link: '/generator/rg'
      },
      {
        icon: 'fa-solid fa-database',
        label: 'Gerador de Pessoa',
        link: '/generator/person'
      },
      {
        icon: 'fa-solid fa-square-check',
        label: 'Validador de CPF',
        link: '/validator/cpf'
      },
      {
        icon: 'fa-solid fa-square-check',
        label: 'Validador de CNPJ',
        link: '/validator/cnpj'
      },
      {
        icon: 'fa-solid fa-square-check',
        label: 'Validador de RG',
        link: '/validator/rg'
      },
      {
        icon: 'fa-solid fa-hotel',
        label: 'Buscador de endereço',
        link: '/search-address'
      }
    ]
  }
}