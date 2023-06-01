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
        tab += `<td><button class="btn btn-outline-warning" onclick="pegarDepartamentID(${departamentos[j].id})">Editar</button>
        <button class="btn btn-outline-danger " onclick="excluirDepartament(${departamentos[j].id})">Excluir</button></td >`;
        tab += `</tr>`;
    } 
    tab += '</tbody>';
    tab += '</table>';

    divTabelaDep.innerHTML = tab;
}


                    
//modal

$(".novoDepartamento").click(function (){
    tituloModal("Cadastro de novo departamento");
    mostrarModal();
    limparForm();
    $('.id').val(0);
});

function tituloModal(texto) {
    $(".modal-title").text(texto);
}
function mostrarModal() {
    var modalElement = document.getElementById('modal');
    var modal = new bootstrap.Modal(modalElement);
    modal.show();
}
function limparForm() {
    $(".name").val(''); 
}
$(".btnSalvar").click(function (){
    var departamentos = {
        id: $('.id').val(),
        name: $('.name').val()
    };
    if (validarForm(departamentos)) {
        if (parseInt(departamentos.id) > 0)
            attDepartament(departamentos);
        criarDepartamentos(departamentos);
    }

});

function criarDepartamentos(departamentos) {
    $.ajax({
        url: "/Departaments/novoDepartamento",
        methood: "POST",
        data: {
            departamentos: departamentos
        }, 
        success: function (departamentoCriado) {
            $("#modal").modal('hide');
            var linhaNovoDepartamento = `<tr id="${departamentoCriado.id}">`;
            linhaNovoDepartament += `<td>${departamentoCriado.name}</td>`;
            linhaNovoDepartament += `<td><button class="btn btn-outline-warning" onclick="pegarDepartamentID(${departamentoCriado.id})">Editar</button><button class="btn btn-outline-danger" onclick="excluirDepartament(${departamentoCriado.id})">Excluir</button></td>`;
            
            linhaNovoDepartament += '</tr>';
            $(".tab tbody").append(linhaNovoDepartament);
            limparForm();
        }   

    });

}


function validarForm(departamentos) {
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