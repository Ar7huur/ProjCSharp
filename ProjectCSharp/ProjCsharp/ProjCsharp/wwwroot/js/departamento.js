//listagem de dados
$(document).ready(function () {
    carregarDadosDep();
});

function carregarDadosDep() {
    $.ajax({
        url: "/Departaments/PegarTodosDep",
        methood: "GET",
        success: function (departamentos) {
            montarTabela(departamentos);
        }

    });
}

function montarTabela(departamentos) {
    var j = 0;
    var divTabelaDep = document.getElementById("divTabelaDep");
    var tab = '<table class="table table-hover">';
    tab += '<thead>';
    tab += '<tr>';
    tab += '<th scope="col">ID</th>';
    tab += '<th scope="col">Nome do departamento</th>';
    tab += '<th scope="col">Ferramentas</th>';
    tab += '</tr>';
    tab += '</thead>';
    tab += '<tbody';

    for (j = 0; j < departamentos.length; j++) {
        tab += `<tr>`;
        tab += `<td>${departamentos[j].id}</td>` 
        tab += `<td>${departamentos[j].name}</td>`;
        tab += `<td><button class="btn btn-outline-warning" onclick="pegarDepPeloId(${departamentos[j].id})">Editar</button>
        <button class="btn btn-outline-danger " onclick="excluirDepPeloId(${departamentos[j].id})">Excluir</button></td >`;
        tab += `</tr>`;
    } 
    tab += '</tbody>';
    tab += '</table>';

    divTabelaDep.innerHTML = tab;
}


                    
//modal
