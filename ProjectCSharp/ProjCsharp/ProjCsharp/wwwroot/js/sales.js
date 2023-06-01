$(document).ready(function () {
    salesrecords(); //carrega os recordes..
});
function salesrecords() {
    $.ajax({
        url: "SalesRecords/obterSalesRecords", //obtem atrav�s controller o caminho para retornar os records
        method: "GET",
        sucess: function (salesrecords) {
            gerarTabela(salesrecords); //monta a tabela com os dados..
        }
    });
}

function salesrecordsTabela(salesrecords) {
    var inicio = 0; //valor inicial da tabela
    var divTabela = document.getElementById("divTabela"); //pega o id da tabela..
    var tab = '<table class="table table-hover">';
    //criando a tabela
    tab += '<thead>'; // concatenar a tabela..
    tab += '<tr>';
    tab += '<th scope="col">ID</th>';
    tab += '<th scope="col">Data</th>';
    tab += '<th scope="col">Valor da venda</th>';
    tab += '</tr>';
    tab += '</thead>';
    //corpo da tabela
    tab += '<tbody>';
   
    //inserir os dados de sales para alimentar a tabela com infos.
    for (inicio = 0; inicio < salesrecords.lenght; inicio++) {
        tab += `<tr id="${salesrecords[inicio].Id}">`;
        tab += `<td>${salesrecords[inicio].Date}</td>`;
        tab += `<td>${salesrecords[inicio].Amount}</td>`;
        tab += `<td><button class="btn btn-outline-warning" onclick="obterSalesRecordsId(${salesrecords[inicio].Id})">Atualizar</button></td>`;  `<td><button class="btn btn-outline-danger " onclick="deleteSalesRecords(${salesrecords[inicio].Id})">Excluir</button></td>`;
        tab += '</tr>'
    }
    tab += '</tbody>';
    tab += '</table>'

    //aplicando a tabela no HTML
    divTabela.innerHTML = tab;

}



  