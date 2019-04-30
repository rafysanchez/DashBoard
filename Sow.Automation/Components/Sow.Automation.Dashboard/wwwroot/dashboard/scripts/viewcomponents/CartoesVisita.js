
function MostraExecucoes(data) {

    var Dados = {};
    clearTimeout(timer);

    Dados.Fluxo = data;
    Dados.FluxoTela = "CartoesVisita";
    Dados.IdAgendamento = "";

    var url = '/Home/DetalheResumoProcesso';

    $.ajax({
        type: "POST",
        url: url,
        contentType: 'application/json; charset=utf-8',
        dataType: 'html',
        data: JSON.stringify(Dados),
        success: function (message) {
           
            $('#ComponentResumo').html(message);
            $('#idModalHistoricoAlteracao').modal('show');
        },

        error: function () {
            alert("Erro");
        }
    });
}
