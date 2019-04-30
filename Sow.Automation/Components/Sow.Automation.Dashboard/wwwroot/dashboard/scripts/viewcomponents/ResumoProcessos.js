$(document).ready(function () {


    var table = $('#idtableResumoProcessos').DataTable({
        "aLengthMenu": [[10, 20, 30, 40, 50, -1], [10, 20, 30, 40, 50, "All"]],
        "pageLength": 10,
        "ordering": false,
        "stateSaveParams": function (settings, data) {
            data.search.search = "";
        },

        stateSaveCallback: function (settings, data) {
            localStorage.setItem('idtableResumoProcessos', JSON.stringify(data));
        },
        stateLoadCallback: function () {
            try {
                return JSON.parse(localStorage.getItem('idtableResumoProcessos'));
            } catch (e) { }
        },

        "order": [],

        "language": {
            "paginate": {
                "first": "Primeiro",
                "last": "Ultimo",
                "next": "Próxima",
                "previous": "Anterior"
            },
            "lengthMenu": "",
            "info": "Mostrando  _END_ de _TOTAL_ entradas",
            "zeroRecords": "Nenhuma Regra Encontrada!",
            "lengthMenu": "Mostrar _MENU_ quantidade",
            "infoEmpty": "Mostrando 0 agendamentos",
            "infoFiltered": "(Filtrado de um total de _MAX_ processos)",
            "search": "_INPUT_",
            "searchPlaceholder": "Procurar por ..."
        },

    });

    $('#idtableResumoProcessos_length').append('<div><label style="margin-top:10px;">Atualizar Dados Tabela</label><a style="margin-left:10px;" onclick="AtualizaResumo();" href="#"><i id="idSpinRefresh" class="fa fa-refresh"></i></a></div>');

});


function IrDetalhesProcesso(dadosCliente) {
  
    var Dados = {};
    Dados.Fluxo = "";
    Dados.FluxoTela = "ResumoProcesso";
    Dados.IdAgendamento = dadosCliente;
    var url = '/Home/DetalheResumoProcesso';

    $.ajax({
        type: "POST",
        url: url,
        contentType: 'application/json; charset=utf-8',
        dataType: 'html',
        data: JSON.stringify(Dados),
        success: function (message) {

            $('#ComponentResumo').html(message);
        },

        error: function () {

        }
    });
}
