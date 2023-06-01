$(document).ready(function () {
    departamentos(); //carrega os departamentos..
});
function departamentos() {
    $.ajax({
        url: "Departaments/obterDepartamentos", //obtem através controller o caminho para retornar os records
        method: "GET",
        sucess: function (departaments) {
            gerarTabela(departaments); //monta a tabela com os dados..
        }
    });
}

function gerarTabela(departaments) {
    var inicio = 0; //valor inicial da tabela
    var divTabDep = document.getElementById("divTabDep"); //pega o id da tabela..
    var tab = '<table class="table table-hover">';
    //criando a tabela
    tab += '<thead>'; // concatenar a tabela..
    tab += '<tr>';
    tab += '<th scope="col">ID</th>';
    tab += '<th scope="col">Nome do departamento</th>';
    tab += '</tr>';
    tab += '</thead>';

    //corpo da tabela
    tab += '<tbody>';

    //inserir os dados de sales para alimentar a tabela com infos.
    for (inicio = 0; inicio < salesrecords.lenght; inicio++) {
        tab += `<tr id="${salesrecords[inicio].Id}">`;
        tab += `<td>${salesrecords[inicio].Name}</td>`;
        tab += `<td><button class="btn btn-outline-warning" onclick="obterSalesRecordsId(${salesrecords[inicio].Id})">Editar Departamento</button></td>`; `<td><button class="btn btn-outline-danger " onclick="deleteSalesRecords(${salesrecords[inicio].Id})">Deletar departamento</button></td>`;
        tab += '</tr>'
    }
    tab += '</tbody>';
    tab += '</table>'

    //aplicando a tabela no HTML
    divTabDep.innerHTML = tab;
    

}




