function AtualizaLista(fluxo) {

    $.ajax({
        type: "POST",
        url: '/Configuracoes/ListarRegras',
        contentType: 'application/json; charset=utf-8',
        dataType: 'html',
        data: JSON.stringify(fluxo),
        success: function (message) {

            $('#idConteudoLista').html(message);
        },

        error: function () {

        }
    });

}
function AtualizarDados(data) {
    $(data).addClass('disableBtn');

    var Dados = RetornaModel(data);
    var desc = Dados.Regra == null || Dados.Regra == "" ? Dados.Descricao : Dados.Regra;
    $.confirm({
            title: 'Informações!',
            content: 'Prosseguir com a ação para os dados de :' + desc,
        buttons: {
            confirmar: function () {
                EnviarAjax(Dados, $(data).attr('url'));  
            },
            cancelar: function () {
                $.alert('Ação Cancelada!');
            },
        }
    });
}
function Editar(data) {

    this.event.preventDefault();
    var texto = '';
    if ($(data).attr('edicao') == 'true') {
        texto = $(data).parent().parent().find('input').val();
        $(data).removeAttr('edicao');
        $(data).parent().parent().find('input').parent().html(texto);
        $(data).parent().parent().find('a[class="tte"]').css('pointer-events', 'none');
        $(data).parent().parent().find('select').attr('disabled', 'true');
        $(data).parent().parent().find('a[onclick="AtualizarDados(this)"]').addClass('disableBtn');

    } else {
        texto = $(data).parent().parent().find('td[alterar="alterar"]').text();
        $(data).parent().parent().find('td[alterar="alterar"]').html('<input type="text" value="' + texto + '"</input>');
        $(data).attr('edicao', 'true');
        $(data).parent().parent().find('a[onclick="AtualizarDados(this)"]').removeClass('disableBtn');
        $(data).parent().parent().find('select').removeAttr('disabled');
    }

    if ($('#idDropDownTipoCadastro').val() == "2") {
        var idEstado = RetornaNumeroValido($(data).attr('idestado'));
        $.ajax({
            type: "POST",
            url: '/Configuracoes/ListarCidades',
            contentType: 'application/json; charset=utf-8',
            dataType: 'html',
            data: JSON.stringify(idEstado),
            success: function (message) {
                ListarCidadesCallBack(JSON.parse(message), data);
            },

            error: function () {

            }
        });
    }
}
function RemoverDados(data) {

    var Dados = RetornaModel(data);

    var desc = Dados.Regra == null || Dados.Regra == "" ? Dados.Descricao : Dados.Regra;
    $.confirm({
        title: 'Informações!',
        content: 'Prosseguir com a ação para os dados de :' + desc,
        buttons: {
            confirmar: function () {
                EnviarAjax(Dados, $(data).attr('url'));
            },
            cancelar: function () {
                $.alert('Ação Cancelada!');
            },
        }
    });
}
function RemoverDadosContrato(data) {

    var contrato = $(data).attr('id');

    $.confirm({
        title: 'Informações!',
        content: 'Prosseguir com a ação para os dados de Contrato ?',
        buttons: {
            confirmar: function () {
                EnviarAjax(contrato, $(data).attr('url'));
            },
            cancelar: function () {
                $.alert('Ação Cancelada!');
            },
        }
    });
}
function RemoverDadosDespesa(data) {

    var despesa = $(data).attr('id');

    $.confirm({
        title: 'Informações!',
        content: 'Prosseguir com a ação para os dados de  despesa ?',
        buttons: {
            confirmar: function () {
                EnviarAjax(despesa, $(data).attr('url'));
            },
            cancelar: function () {
                $.alert('Ação Cancelada!');
            },
        }
    });
}
function ListarCidadesCallBack(json, data) {
    var num = 0;
    $(json).each(function () {
        $(data).parent().parent().find('select').append('<option value="' + json[num]["id"] + '">' + json[num]["descricao"] + '</option>');
        num++;
    });
}
function RetornaModel(data) {

    var Dados = {};
    Dados.Id = RetornaNumeroValido($(data).attr('id'));
    Dados.IdEstado = RetornaNumeroValido($(data).attr('idestado'));
    Dados.IdComarca = RetornaNumeroValido($(data).attr('idcomarca'));
    Dados.IdCidade = RetornaNumeroValido($(data).attr('idcidade'));
    Dados.IdBairro = RetornaNumeroValido($(data).attr('idbairro'));
    Dados.Regra = $(data).parent().parent().find('input').val();
    Dados.Descricao = $(data).parent().parent().find('input').val();

    if ($('#idDropDownTipoCadastro').val() == "2") {
        Dados.IdComarca = $(data).parent().parent().find('select').val();
    }


    return Dados;
}
//CUSTAS
function RemoverDadosCusta(data) {

    var Dados = RetornaModelCusta(data);
    $.confirm({
        title: 'Informações!',
        content: 'Prosseguir com a ação para os dados de Custas ?',
        buttons: {
            confirmar: function () {
                EnviarAjax(Dados, $(data).attr('url'));
            },
            cancelar: function () {
                $.alert('Ação Cancelada!');
            },
        }
    });
}
function AtualizarDadosCusta(data) {
    $(data).addClass('disableBtn');

    var Dados = RetornaModelCusta(data);
    $.confirm({
        title: 'Informações!',
        content: 'Prosseguir com a ação para os dados de Custas ?:',
        buttons: {
            confirmar: function () {
                EnviarAjax(Dados, $(data).attr('url'));
            },
            cancelar: function () {
                $.alert('Ação Cancelada!');
            },
        }
    });
}
function RetornaModelCusta(data) {

    var Dados = {};
    Dados.IdEstado = $(data).attr('vlestado');
    Dados.De = $(data).parent().parent().find('input[de="de"]').val();
    Dados.Ate = $(data).parent().parent().find('input[ate="ate"]').val();
    return Dados;
}
function EnviarAjax(dados, url) {
    $.ajax({
        type: "POST",
        url: url,
        contentType: 'application/json; charset=utf-8',
        dataType: 'html',
        data: JSON.stringify(dados),
        success: function (message) {

            $.alert({
                title: 'Status!',
                content: message,
            });


            AtualizaLista($('#idDropDownTipoCadastro').val());
        },

        error: function () {

        }
    });
}
function EditarCustas(data) {

    this.event.preventDefault();
    var textoDe = '';
    var textoAte = '';


    if ($(data).attr('edicao') == 'true') {
        textoDe = $(data).parent().parent().find('input[de="de"]').val();
        textoAte = $(data).parent().parent().find('input[ate="ate"]').val();
        $(data).removeAttr('edicao');
        $(data).parent().parent().find('td[de="de"]').html(textoDe);
        $(data).parent().parent().find('td[ate="ate"]').html(textoAte);
        $(data).parent().parent().find('a[onclick="AtualizarDadosCusta(this)"]').addClass('disableBtn');

    } else {
        textoDe = $(data).parent().parent().find('td[de="de"]').text();
        textoAte = $(data).parent().parent().find('td[ate="ate"]').text();
        $(data).parent().parent().find('td[de="de"]').html('<input de="de" type="number" min="0" max="5" value="' + textoDe + '"</input>');
        $(data).parent().parent().find('td[ate="ate"]').html('<input ate="ate" type="number" min="0" max="5" value="' + textoAte + '"</input>');
        $(data).attr('edicao', 'true');
        $(data).parent().parent().find('a[onclick="AtualizarDadosCusta(this)"]').removeClass('disableBtn');
    }
}