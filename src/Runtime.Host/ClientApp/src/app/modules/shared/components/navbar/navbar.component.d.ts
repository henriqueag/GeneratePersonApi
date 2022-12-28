export interface INavbar {
  logoImg: string,
  logoAltText: string,
  logoTitle: string,
  logoDescription: string,
  navbarItems: INavbarItems[]
}

export interface INavbarItems {
  link: string,
  icon: string
}