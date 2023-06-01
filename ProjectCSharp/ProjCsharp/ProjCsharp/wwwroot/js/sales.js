$(document).ready(function () {
    salesrecords(); //carrega os recordes..
});
function salesrecords() {
    $.ajax({
        url: "/SalesRecords/obterSalesRecords", //obtem através controller o caminho para retornar os records
        method: "GET",
        success: function (salesrecords) {
            salesrecordsTabela(salesrecords); //monta a tabela com os dados..
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
    
    tab += '<th scope="col">Data</th>';
    tab += '<th scope="col">Valor da venda</th>';
    tab += '<th scope="col">Id do vendedor</th>';
    tab += '<th scope="col">Ferramentas</th>';
    tab += '<th></th>';
    
    
    tab += '</tr>';
    tab += '</thead>';
    //corpo da tabela
    tab += '<tbody>';
   
    //inserir os dados de sales para alimentar a tabela com infos.
    for (inicio = 0; inicio < salesrecords.length; inicio++) {
        tab += `<tr id="${salesrecords[inicio].Id}">`;
        tab += `<td>${salesrecords[inicio].date}</td>`;
        tab += `<td>${salesrecords[inicio].amount}</td>`;
        tab += `<td>${salesrecords[inicio].sellerId}</td>`;
        
        tab += `<td><button class="btn btn-outline-warning" onclick="criarDepartamento(${salesrecords[inicio].Id})">Atualizar</button>
                    <button class="btn btn-outline-danger " onclick="deleteSalesRecords(${salesrecords[inicio].Id})">Excluir</button></td>`;
        tab += '</tr>';
    }
    tab += '</tbody>';
    tab += '</table>';

    //aplicando a tabela no HTML
    divTabela.innerHTML = tab;

}



  
