# Document Generator

Essa api consegue gerar dados válidos de pessoas, validar CPF, RG e CNPJ, além de buscar cidades e estados do Brasil.

## Controller DocGenerator

Esse controlador serve para gerar documentos pessoais válidos.  
Abaixo os endpoints: 

- /api/DocGenerate/cpf_generator
- /api/DocGenerate/cnpj_generator
- /api/DocGenerate/rg_generator
- /api/DocGenerate/cidades
- /api/DocGenerate/estados

## Controller PersonGenerate

Esse controlador permitir gerar pessoas com nome, cpf, data de nascimento, endereço...  

Os parâmetros da requisição são passados via query string.

- /api/PersonGenerate/onePerson
    - Sem nenhum parâmetro será gerado uma pessoa aleatória.
- api/PersonGenerate/onePerson?idade=&estado=&cidade=&gerarComPonto=true
    - Dessa forma poderá especificar os parametros para geração, seguindo a estrutura do enconding de url
