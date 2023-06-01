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



//modal

$(".novoSalesRecord").click(function () {
    tituloModal("Cadastro de novo recorde de vendas");
    mostrarModalsr();
    limparFormsr();
    $('.srId').val(0);
});

function tituloModal(texto) {
    $(".modal-title").text(texto);
}
function mostrarModalsr() {
    var modalElement = document.getElementById('modal-sr');
    var modal = new bootstrap.Modal(modalElement);
    modal.show();
}
function limparFormsr() {
    $(".Date").val('');
    $(".Amount").val('');
    $(".SellerId").val('');
}


$(".btnSave").click(function () {
    var salesRecords = {
        id: $('.srId').val(),
        date: $('.Date').val(),
        amout: $('.Amount').val(),
        seller: $('.SellerId').val(), 

    };
    if (validarForm(salesRecords)) {
        if (parseInt(sellers.id) > 0)
            editarSalesRecords(salesRecords);
        criarSalesRecords(salesRecords);
    }

});

function criarSalesRecords(salesRecords) {
    $.ajax({
        url: "/SalesRecords/criarSalesRecords",
        methood: "POST",
        data: {
            sellers: sellers
        },
        success: function (salesRecords) {
            $("#modal").modal('hide');
            var linhaNovosr = `<tr id="${departamentoCriado.id}">`;
            linhaNovosr += `<td>${departamentoCriado.name}</td>`;
            linhaNovosr += `<td><button class="btn btn-outline-warning" onclick="pegarDepartamentID(${departamentoCriado.id})">Editar</button><button class="btn btn-outline-danger" onclick="excluirDepartament(${departamentoCriado.id})">Excluir</button></td>`;

            linhaNovosr += '</tr>';
            $(".tab tbody").append(linhaNovosr);
            limparFormsr();
        }

    });

}


function validarFormsr(salesRecords) {
    let nomeValido = validarNome(departamentos.name);
    if (nomeValido == true)
        return true;
    return false;
}

function validarNome(name) {
    let nomeValido = true;
    if (name.trim() === '' || name === undefined) {
        $(".name").addClass('is-invalid');
        $("erroName").text("Preencha o campo corretamente.");
        $("erroName").removeClass("d-none");
        nomeValido = false;
    }
    else if (name.length > 30) {
        $(".name").addClass('is-invalid');
        $("erroName").text("Use menos que 30 caracteres.");
        $("erroName").removeClass("d-none");
        nomeValido = false;
    }
    else {
        $(".name").removeClass('is-invalid');
        $(".name").addClass('is-valid');
        $(".name").addClass('d-none');
        nomeValido = true;
    }
    return nomeValido;
}




  
