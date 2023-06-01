$(document).ready(function () {
    salesrecords(); //carrega os recordes..
});
function salesrecords() {
    $.ajax({
        url: "/Sellers/obterSellers", //obtem atrav�s controller o caminho para retornar os records
        method: "GET",
        success: function (sellers) {
            sellersTab(sellers); //monta a tabela com os dados..
        }
    });
}

function sellersTab(sellers) {
    var inicio = 0; //valor inicial da tabela
    var divTabSellers = document.getElementById("divTabSellers"); //pega o id da tabela..
    var tab = '<table class="table table-hover">';
    //criando a tabela
    tab += '<thead>'; // concatenar a tabela..
    tab += '<tr>';

    tab += '<th scope="col">Nome</th>';
    tab += '<th scope="col">Email</th>';
    tab += '<th scope="col">CPF</th>';
    tab += '<th scope="col">Salario</th>';
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
        tab += `<td>${sellers[inicio].cpf}</td>`;
        tab += `<td>${sellers[inicio].salario}</td>`;
        tab += `<td>${sellers[inicio].departamentid}</td>`;
        tab += `<td><button class="btn btn-outline-warning" onclick="obterSalesRecordsId(${sellers[inicio].Id})">Atualizar</button></td><td><button class="btn btn-outline-danger " onclick="deleteSalesRecords(${sellers[inicio].Id})">Excluir</button></td>`;
        tab += '</tr>'
    }
    tab += '</tbody>';
    tab += '</table>'

    //aplicando a tabela no HTML
    divTabSellers.innerHTML = tab;

}