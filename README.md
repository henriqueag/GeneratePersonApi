# Document Generator
Projeto em desenvolvimento...

Com essa api você vai conseguir validar documento como RG, CPF e CNPJ, além de conseguir gerar esses documentos válidos e já formatados.

Outra funcionalidade é para a geração de uma pessoa com nome, cpf, rg, endereço...

## Controller DocGenerator
Esse controlador permiti gerar documentos pessoais válidos.

Abaixo os endpoints:

* /api/DocGenerate/cpf_generator
* /api/DocGenerate/cnpj_generator
* /api/DocGenerate/rg_generator
* /api/DocGenerate/cidades
* /api/DocGenerate/estados

## Controller PersonGenerate
Esse controlador permitir gerar pessoas com nome, cpf, data de nascimento, endereço...

Os parâmetros da requisição são passados via query string.

Abaixo os endpoints:
* /api/PersonGenerate/onePerson
    * api/PersonGenerate/onePerson?idade=&estado=&cidade=&gerarComPonto=true
* /api/PersonGenerate/listPerson
    * /api/PersonGenerate/listPerson?qtdPessoas=&idade=&estado=&cidade=&gerarComPonto=true

## Controller Validator
Esse controlador permitir validar documentos pessoais.

Abaixo os endpoints:

* /api/Validator/cpf_validator
* /api​/Validator​/cnpj_validator
* /api​/Validator​/rg_validator

## Observação
Alguns endpoints usam query string, então para uma implementação em um site ou projeto de teste terá que entrar no código dos respectivos controladores para verificar os nomes dos parâmentros
