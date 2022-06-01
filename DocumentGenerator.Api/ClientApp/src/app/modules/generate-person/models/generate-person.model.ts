export interface GeneratePerson {
    nome: string
    cpf: string
    rg: string
    dataNasc: string
    idade: number
    telefone: string
    email: string
    enderecoApi: Endereco
}

export interface Endereco {
    cep: string
    logradouro: string
    complemento: string
    bairro: string
    cidade: string
    uf: string
    ddd: string
}
