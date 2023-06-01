$(document).ready(function () {
    departamentos(); //carrega os departamentos..
});
function departamentos() {
    $.ajax({
        url: "/Departaments/obterDepartamentos",
        method: "GET",
        success: function (departaments) {
            gerarTab(departaments); //monta a tabela com os dados..
        }
    });
}//"pegarDepartamentID", "Departaments"

function gerarTab(departaments) {
    var inicio = 0; //valor inicial da tabela
    var divTabDep = document.getElementById("divTabDep"); //pega o id da tabela..
    var tab = '<table class="table table-hover" id="tabid">';
    //criando a tabela
    tab += '<thead>'; // concatenar a tabela..
    tab += '<tr>';
    tab += '<th scope="col">ID</th>';
    tab += '<th scope="col">Nome do departamento</th>';
    tab += '<th scope="col">Ferramentas</th>';
    tab += '<th></th>';
    tab += '</tr>';
    tab += '</thead>';

    //corpo da tabela
    tab += '<tbody>';

    //inserir os dados de sales para alimentar a tabela com infos.
    for (inicio = 0; inicio < departaments.length; inicio++) {
        tab += `<tr id="${departaments[inicio].id}">`;
        tab += `<td>${departaments[inicio].name}</td>`;
        tab += `<td><button class="btn btn-outline-warning" onclick="obterDepartamentId(${departaments[inicio].depid})">Editar Departamento</button></td> <td><button class="btn btn-outline-danger " onclick="deleteDepartamento(${departaments[inicio].depid})">Deletar departamento</button></td>`;
        tab += '</tr>'
    }
    tab += '</tbody>';
    tab += '</table>'

    //aplicando a tabela no HTML
    divTabDep.innerHTML = tab;
}
 
    






