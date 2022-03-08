document.addEventListener('DOMContentLoaded', () => {
    const url = "http://localhost:5000/api/PersonGenerete/Estados"
    fetch(url)
        .then(function (response) {
            if (response.ok) {
                return response.json()
            }
            else {
                throw new Error()
            }
        })
        .then((jsonData) => {
            CriaOptionSelect('option', 'uf', '');

            jsonData.forEach(element => {
                CriaOptionSelect('option', 'uf', element)
            });
        })
        .catch((err) => {
            console.log('Error: ' + err.message)
        });

    for (let i = 18; i <= 65; i++) {
        CriaOptionSelect('option', 'idadeParam', i);
    }
});

GetElement('uf').addEventListener('change', () => {
    fetch(`http://localhost:5000/api/PersonGenerete/Cidades?estadosBR=${document.getElementById('uf').value}`)
        .then(response => {
            if (response.ok) {
                return response.json()
            }
            throw new Error();
        })
        .then(result => {
            if (GetElement('uf').value == '') {
                GetElement('cidade').options.length = 0;
                CriaOptionSelect('option', 'cidade', 'Selecione a cidade');
            }
            if (GetElement('uf').value != '') {
                result.forEach(element => {
                    CriaOptionSelect('option', 'cidade', element)
                });
            }
        })
        .catch(err => {
            console.log(err.message);
        });
});

GetElement('quantidade').addEventListener('change', () => {
    let qtd = parseInt(GetElement('quantidade').value);
    if (qtd == 1) {
        GetElement('dataForm').style.display = '';
        GetElement('formulario').style.display = '';
        GetElement('dataJson').classList.remove('active')
    }
    if (qtd > 1) {
        GetElement('dataForm').style.display = 'none';
        GetElement('formulario').style.display = 'none';
        GetElement('dataJson').classList.add('active')
        GetElement('json').classList.add('active')
    }
});

GetElement('button').addEventListener('click', RequesteServer);

GetElement('resultJson').onclick = () => $(GetElement('resultJson')).select();

function RequesteServer() {
    let idade = GetElement('idadeParam').value == '' ? '' : parseInt(GetElement('idadeParam').value);
    let estado = GetElement('uf').value == '' ? '' : GetElement('uf').value;
    let cidade = GetElement('cidade').value == 'Selecione a cidade' ? '' : encodeURI(GetElement('cidade').value);
    let pontuacao = GetElement('gerarComPonto').value == 'Sim' ? true : false;
    let qtd = parseInt(GetElement('quantidade').value);
    if (qtd == 1) {
        let url = `http://localhost:5000/api/PersonGenerete/OnePerson?idade=${idade}&estado=${estado}&cidade=${cidade}&gerarComPonto=${pontuacao}`;
        fetch(url)
            .then(response => {
                if (response.ok) {
                    return response.json();
                }
                throw new Error();
            })
            .then(result => {
                // Formulario
                let dateInput = new Date(result.dataNasc);
                GetElement('nome').value = result.nome;
                GetElement('cpf').value = result.cpf;
                GetElement('rg').value = result.rg;
                GetElement('dataNascimento').value = dateInput.toLocaleDateString();
                GetElement('idade').value = result.idade;
                GetElement('telefone').value = result.telefone;
                GetElement('email').value = result.email;
                GetElement('cep').value = result.enderecoApi.cep;
                GetElement('logradouro').value = result.enderecoApi.logradouro;
                GetElement('complemento').value = result.enderecoApi.complemento;
                GetElement('bairro').value = result.enderecoApi.bairro;
                GetElement('cidade_input').value = result.enderecoApi.cidade;
                GetElement('uf_input').value = result.enderecoApi.uf;

                // Json
                GetElement('resultJson').value = JSON.stringify(result, null, 3);

            }).catch(err => console.log(err.message));
    }
    if (qtd > 1) {
        let url = `http://localhost:5000/api/PersonGenerete/ListPerson?qtdPessoas=${qtd}&idade=${idade}&estado=${estado}&cidade=${cidade}&gerarComPonto=${pontuacao}`;
        console.log(url);
        fetch(url)
            .then(response => {
                if (response.ok) {
                    return response.json();
                }
                throw new Error();
            })
            .then(result => {
                // Json
                GetElement('resultJson').value = JSON.stringify(result, null, 3);
            })
            .catch(err => console.log(err.message));
    }
}

function CriaOptionSelect(elemento, elementId, valor) {
    option = document.createElement(elemento);
    option.text = valor
    document.getElementById(elementId).appendChild(option);
}

function GetElement(idElement) {
    return document.getElementById(idElement);
}