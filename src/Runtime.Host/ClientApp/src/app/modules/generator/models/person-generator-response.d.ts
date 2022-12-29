export interface IPersonGeneratorResponse {
  name: string,
  cpf: string,
  rg: string,
  birthDate: Date,
  age: number,
  phone: string,
  email: string,
  address: {
    street: string,
    district: string,
    complement: string,
    city: string,
    cep: string,
    state: string,
    ddd: number
  }
}