$('#idDropDownTipoCadastro').change(function () {

    var Dados = {};
    Dados.DropDown = "default";
    var fluxo = $('#idDropDownTipoCadastro').val();

    $.ajax({
        type: "POST",
        url: '/Configuracoes/PopulaOpcoesDropDown',
        contentType: 'application/json; charset=utf-8',
        dataType: 'html',
        data: JSON.stringify(Dados),
        success: function (message) {

            $('#idTodosDropDown').html(message);
            PopulaItemCadastro(fluxo);
            $('#idConteudoDropDown button').prop('disabled', 'true');

            if (fluxo == 6 || fluxo == 7 || fluxo == 8) {
                $('#idConteudoDropDown button').removeAttr('disabled');
            }
           
        },

        error: function () {
         
        }
    });


    AtualizaLista(fluxo);
    

});


function BloqueiaBotao(idBtn) {
    $(idBtn).removeAttr('disabled');

    $('#idItensCadastro select').each(function () {
        if ($(this).val() == "default") {
            $(idBtn).prop('disabled', 'true');
        }
    });
}
function PopulaItemCadastro(menu) {

    $('#idItensCadastro').fadeIn('slow');
    $('#idConteudoDropDown').html('');

    var Estados = $('#idDropDownEstados').parent().html();
    var Comarcas = $('#idDropDownComarcas').parent().html();
    var Cidades = $('#idDropDownCidades').parent().html();
    var Bairros = $('#idDropDownBairros').parent().html();
   

    if (menu == "0") {
        $('#idItensCadastro').fadeOut('slow');
    }
    
    else if (menu == "1") {

        var Botao = RetornaBotao('Cadastrar Comarca', 'idCadastrarComarca','CadastrarComarca()');
        var Input = RetornaInput('Digite a Comarca');

        $('#iddropDownDefault').html(Estados);
        $('#idConteudoDropDown').html(Input + Botao);

    }
    else if (menu == "2") {

        var Botao = RetornaBotao('Cadastrar Cidade', 'idCadastrarCidade', 'CadastrarCidade()');
        var Input = RetornaInput('Digite a Cidade');

        $('#iddropDownDefault').html(Estados);
        $('#idConteudoDropDown').html(Comarcas + Input + Botao);
    }
    else if (menu == "3") {

        var Botao = RetornaBotao('Cadastrar Bairro', 'idCadastrarBairro', 'CadastrarBairro()');
        var Input = RetornaInput('Digite o Bairro');

        $('#iddropDownDefault').html(Estados);
        $('#idConteudoDropDown').html(Comarcas + Cidades + Input + Botao);
    }
    else if (menu == "4") {

        var Botao = RetornaBotao('Cadastrar Regra', 'idCadastrarRegra', 'CadastrarRegra()');
        var Input = RetornaInput('Digite Digite o Foro');

        $('#iddropDownDefault').html(Estados);
        $('#idConteudoDropDown').html(Comarcas + Cidades + Input + Botao);
    }
    else if (menu == "5") {

        var Botao = RetornaBotao('Cadastrar Regra', 'idCadastrarRegraBairro', 'CadastrarRegraBairro()');
        var Input = RetornaInput('Digite Digite o Foro');

        $('#iddropDownDefault').html(Estados);
        $('#idConteudoDropDown').html(Comarcas + Cidades + Bairros + Input + Botao);
       
    }

    else if (menu == "6") {

        var Botao = RetornaBotao('Cadastrar Contrato', 'idCadastrarContrato', 'CadastrarContrato()');
        var Input = RetornaInput('Digite o Contrato');

        $('#iddropDownDefault').html('');
        $('#idConteudoDropDown').html(Input + Botao);

    }

    else if (menu == "7") {

        var Botao = RetornaBotao('Cadastrar Despesa', 'idCadastrarDespesa', 'CadastrarDespesa()');
        var Input = RetornaInput('Digite a Despesa');

        $('#iddropDownDefault').html('');
        $('#idConteudoDropDown').html(Input + Botao);

    }

    else if (menu == "8") {

        $('#iddropDownDefault').html(Estados);
        $('#idConteudoDropDown').html(' <label style="margin-left:30px;">Quantidade Minina</label> <input style="margin-left:30px;" id="idDe" placeholder="De..." min="0" max="5" type="number" /> <label style="margin-left:30px;">Quantidade Minina</label> <input style="margin-left:30px;" id="idAte" placeholder="Ate..." min="0" max="5" type="number" /> <button style="margin-left:30px;" onclick="CadastrarCusta(this)" class="btn btn-custom-modal">Cadastrar Custa</button>');

    }
     
    
}
function RetornaBotao(parametro, id,funcao) {

    return '<button  style="margin-left:30px;" onclick="'+funcao+'" class="btn btn-custom-modal"  id="' + id + '">' + parametro + '</button > ';
}
function RetornaInput(parametro) {

    return '<input class="dropDownStyle"  type="text" placeholder="' + parametro + '"> ';
}
function RetornaNumeroValido(dados) {
    var num = isNaN(parseInt(dados)) == true ? 0 : parseInt(dados);

    return num;
}

function CadastrarComarca() {

    var Dados = {};

    Dados.IdEstado = RetornaNumeroValido($('#idDropDownEstados').val());
    Dados.Descricao = $('#idConteudoDropDown input').val();

    var desc = Dados.Regra == null || Dados.Regra == "" ? Dados.Descricao : Dados.Regra;
    $.confirm({
        title: 'Informações!',
        content: 'Prosseguir com a ação para os dados de :' + desc,
        buttons: {
            confirmar: function () {
                $.ajax({
                    type: "POST",
                    url: '/Configuracoes/CadastrarComarca',
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'html',
                    data: JSON.stringify(Dados),
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
            },
            cancelar: function () {
                $.alert('Ação Cancelada!');
            },
        }
    });

}
function CadastrarCidade() {

    var Dados = {};
    Dados.IdEstado = RetornaNumeroValido($('#idDropDownEstados').val());
    Dados.IdComarca = RetornaNumeroValido($('#idDropDownComarcas').val());
    Dados.Descricao = $('#idConteudoDropDown input').val();


    var desc = Dados.Regra == null || Dados.Regra == "" ? Dados.Descricao : Dados.Regra;

    $.confirm({
        title: 'Informações!',
        content: 'Prosseguir com a ação para os dados de :' + desc,
        buttons: {
            confirmar: function () {
                $.ajax({
                    type: "POST",
                    url: '/Configuracoes/CadastrarCidade',
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'html',
                    data: JSON.stringify(Dados),
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

            },
            cancelar: function () {
                $.alert('Ação Cancelada!');
            },
        }
    });
   
   
}
function CadastrarBairro () {

    var Dados = {};
    Dados.IdCidade = $('#idDropDownCidades').val();
    Dados.Descricao = $('#idConteudoDropDown input').val();

    var desc = Dados.Regra == null || Dados.Regra == "" ? Dados.Descricao : Dados.Regra;

    $.confirm({
        title: 'Informações!',
        content: 'Prosseguir com a ação para os dados de :' + desc,
        buttons: {
            confirmar: function () {
                $.ajax({
                    type: "POST",
                    url: '/Configuracoes/CadastrarBairro',
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'html',
                    data: JSON.stringify(Dados),
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

            },
            cancelar: function () {
                $.alert('Ação Cancelada!');
            },
        }
    });

   

}
function CadastrarRegra () {



    var Dados = {};
    Dados.IdEstado = $('#idDropDownEstados').val();
    Dados.IdCidade = $('#idDropDownCidades').val();
    Dados.IdComarca = $('#idDropDownComarcas').val();
    Dados.IdBairro = $('#idDropDownBairros').val();
    Dados.Regra = $('#idConteudoDropDown input').val();
    console.log(Dados);

    var desc = Dados.Regra == null || Dados.Regra == "" ? Dados.Descricao : Dados.Regra;

    $.confirm({
        title: 'Informações!',
        content: 'Prosseguir com a ação para os dados de :' + desc,
        buttons: {
            confirmar: function () {
                $.ajax({
                    type: 'POST',
                    url: '/Configuracoes/CadastrarRegra',
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'html',
                    data: JSON.stringify(Dados),
                    success: function (message) {
                        $.alert({
                            title: 'Status!',
                            content: message,
                        });

                        AtualizaLista($('#idDropDownTipoCadastro').val());
                    },

                    error: function (error) {
                        $.alert({
                            title: 'Status!',
                            content: error.responseText,
                        });

                        AtualizaLista($('#idDropDownTipoCadastro').val());
                    }
                });

            },
            cancelar: function () {
                $.alert('Ação Cancelada!');
            },
        }
    });

    
   

}
function CadastrarRegraBairro () {

    var Dados = {};
    Dados.IdEstado = $('#idDropDownEstados').val();
    Dados.IdCidade = $('#idDropDownCidades').val();
    Dados.IdComarca = $('#idDropDownComarcas').val();
    Dados.IdBairro = $('#idDropDownBairros').val();
    Dados.Regra = $('#idConteudoDropDown input').val();


    var desc = Dados.Regra == null || Dados.Regra == "" ? Dados.Descricao : Dados.Regra;

    $.confirm({
        title: 'Informações!',
        content: 'Prosseguir com a ação para os dados de :' + desc,
        buttons: {
            confirmar: function () {
                $.ajax({
                    type: "POST",
                    url: '/Configuracoes/CadastrarRegraBairro',
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'html',
                    data: JSON.stringify(Dados),
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

            },
            cancelar: function () {
                $.alert('Ação Cancelada!');
            },
        }
    });


  

}
function CadastrarContrato() {

    var contrato = $('#idConteudoDropDown input').val();

    $.confirm({
        title: 'Informações!',
        content: 'Prosseguir com a ação para os dados de Despesa ?',
        buttons: {
            confirmar: function () {
                $.ajax({
                    type: "POST",
                    url: '/Configuracoes/CadastrarContrato',
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'html',
                    data: JSON.stringify(contrato),
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

            },
            cancelar: function () {
                $.alert('Ação Cancelada!');
            },
        }
    });




}
function CadastrarDespesa() {

    var despesa = $('#idConteudoDropDown input').val();

    $.confirm({
        title: 'Informações!',
        content: 'Prosseguir com a ação para os dados de Despesa ?',
        buttons: {
            confirmar: function () {
                $.ajax({
                    type: "POST",
                    url: '/Configuracoes/CadastrarDespesa',
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'html',
                    data: JSON.stringify(despesa),
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

            },
            cancelar: function () {
                $.alert('Ação Cancelada!');
            },
        }
    });




}
function CadastrarCusta(data) {

    var Dados = {};
    Dados.IdEstado = $('#idDropDownEstados').val();
    Dados.De = $('#idDe').val();
    Dados.Ate = $('#idAte').val();
    $.ajax({
        type: "POST",
        url: '/Configuracoes/CadastrarCusta',
        contentType: 'application/json; charset=utf-8',
        dataType: 'html',
        data: JSON.stringify(Dados),
        success: function (message) {

            $.alert({
                title: 'Status!',
                content: message,
                buttons: {
                    Ok: function () {
                        AtualizaLista($('#idDropDownTipoCadastro').val());
                    },
                }

            });
        },

        error: function () {

        }
    });

}

function OnchangeEstados() {


    var Dados = {};
    Dados.DropDown = "Comarcas";
    Dados.IdEstado = RetornaNumeroValido($('#idDropDownEstados').val());

        $.ajax({
            type: "POST",
            url: '/Configuracoes/PopulaOpcoesDropDown',
            contentType: 'application/json; charset=utf-8',
            dataType: 'html',
            data: JSON.stringify(Dados),
            success: function (message) {
                $('#idDropDownComarcas').html($(message).find('#idDropDownComarcas').html());
                $('#idDropDownCidades').html($(message).find('#idDropDownCidades').html());
                $('#idDropDownBairros').html($(message).find('#idDropDownBairros').html());
                BloqueiaBotao('#idCadastrarComarca');
                BloqueiaBotao('#idCadastrarCidade');
                BloqueiaBotao('#idCadastrarBairro');
                BloqueiaBotao('#idCadastrarRegra');
                BloqueiaBotao('#idCadastrarRegraBairro');
            },

            error: function () {
                
            }
        });
}
function OnchangeComarcas() {

    var Dados = {};
    Dados.DropDown = "Cidades";
    Dados.IdEstado = RetornaNumeroValido($('#idDropDownEstados').val());
    Dados.IdComarca = RetornaNumeroValido($('#idDropDownComarcas').val());

    $.ajax({
        type: "POST",
        url: '/Configuracoes/PopulaOpcoesDropDown',
        contentType: 'application/json; charset=utf-8',
        dataType: 'html',
        data: JSON.stringify(Dados),
        success: function (message) {
            $('#idDropDownCidades').html($(message).find('#idDropDownCidades').html());
            $('#idDropDownBairros').html($(message).find('#idDropDownBairros').html());
            BloqueiaBotao('#idCadastrarComarca');
            BloqueiaBotao('#idCadastrarCidade');
            BloqueiaBotao('#idCadastrarBairro');
            BloqueiaBotao('#idCadastrarRegra');
            BloqueiaBotao('#idCadastrarRegraBairro');
        },

        error: function () {

        }
    });

}
function OnchangeCidades() {

    var Dados = {};
    Dados.DropDown = "Bairros";
    Dados.IdEstado = RetornaNumeroValido($('#idDropDownEstados').val());
    Dados.IdCidade = RetornaNumeroValido($('#idDropDownCidades').val());

    $.ajax({
        type: "POST",
        url: '/Configuracoes/PopulaOpcoesDropDown',
        contentType: 'application/json; charset=utf-8',
        dataType: 'html',
        data: JSON.stringify(Dados),
        success: function (message) {
            $('#idDropDownBairros').html($(message).find('#idDropDownBairros').html());
            BloqueiaBotao('#idCadastrarComarca');
            BloqueiaBotao('#idCadastrarCidade');
            BloqueiaBotao('#idCadastrarBairro');
            BloqueiaBotao('#idCadastrarRegra');
            BloqueiaBotao('#idCadastrarRegraBairro');
        },

        error: function () {

        }
    });

}
function OnchangeBairros() { 
    BloqueiaBotao('#idCadastrarComarca');
    BloqueiaBotao('#idCadastrarCidade');
    BloqueiaBotao('#idCadastrarBairro');
    BloqueiaBotao('#idCadastrarRegra');
    BloqueiaBotao('#idCadastrarRegraBairro');
}







