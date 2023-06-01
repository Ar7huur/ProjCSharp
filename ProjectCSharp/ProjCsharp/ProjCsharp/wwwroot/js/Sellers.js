$(document).ready(function () {
    seller(); //carrega os recordes..
});
function seller() {
    $.ajax({
        url: "/Sellers/obterSellers", //obtem através controller o caminho para retornar os records
        method: "GET",
        success: function (sellers) {
            sellersTab(sellers); //monta a tabela com os dados..
        }
    });
}

function sellersTab(sellers) {
    var inicio = 0; //valor inicial da tabela
    var divTabSeller = document.getElementById("divTabSellers"); //pega o id da tabela..
    var tab = '<table class="table table-hover">';
    //criando a tabela
    tab += '<thead>'; // concatenar a tabela..
    tab += '<tr>';
    tab += '<th scope="col">Nome</th>';
    tab += '<th scope="col">Email</th>';
    tab += '<th scope="col">CPF</th>';
    tab += '<th scope="col">Salario</th>';
    tab += '<th scope="col">Departamento ID</th>';
    tab += '<th></th>';
    tab += '</tr>';
    tab += '</thead>';
    //corpo da tabela
    tab += '<tbody>';

    //inserir os dados de sales para alimentar a tabela com infos.
    for (inicio = 0; inicio < sellers.length; inicio++) {
        tab += `<tr id="${sellers[inicio].id}">`;
        tab += `<td>${sellers[inicio].name}</td>`;
        tab += `<td>${sellers[inicio].email}</td>`;
        tab += `<td>${sellers[inicio].cPF}</td>`;
        tab += `<td>${sellers[inicio].baseSalary }</td>`;
        tab += `<td>${sellers[inicio].departament}</td>`;
        tab += `<td><button class="btn btn-outline-warning" onclick="obterSellersId(${sellers[inicio].id})">Atualizar</button></td><td><button class="btn btn-outline-danger" onclick="deleteSellers(${sellers[inicio].id})">Excluir</button></td>`;
        tab += '</tr>'
    }
    tab += '</tbody>';
    tab += '</table>'

    //aplicando a tabela no HTML
    divTabSeller.innerHTML = tab;

}