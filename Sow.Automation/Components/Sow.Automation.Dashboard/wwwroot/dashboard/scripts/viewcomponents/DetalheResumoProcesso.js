$(document).ready(function () {

    clearTimeout(timer)
    $(document).ready(function () {

        $('#idtableDetalheResumoProcessos').DataTable({
            "stateSave": true,
            "bPaginate": true,
            "info": false,
            "stateSaveParams": function (settings, data) {
                data.search.search = "";
            },

            stateSaveCallback: function (settings, data) {
                localStorage.setItem('idtableDetalheResumoProcessos', JSON.stringify(data));
            },
            stateLoadCallback: function () {
                try {
                    return JSON.parse(localStorage.getItem('idtableDetalheResumoProcessos'));
                } catch (e) { }
            },

            "order": [],

            "language": {
                "lengthMenu": "",
                "zeroRecords": "Processo não encontrado!",

                "infoEmpty": "Mostrando 0 processos",
                "infoFiltered": "(Filtrado de um total de _MAX_ processos)",
                "search": "_INPUT_",
                "searchPlaceholder": "Procurar por ..."
            },

        });


    });

});


$('#idModalHistoricoAlteracao').modal('show');

function MostraDetalhes(id) {
   
    $(".hideDados").hide();
    $("#bnt_voltar").removeClass("hide");
    $(".btnhide").hide();
    $(id).removeClass("hide");
    $('#idtableDetalheResumoProcessos_wrapper').hide();
}

function VoltaParaLista() {
    
    $('#idtableDetalheResumoProcessos_wrapper').show();
    $(".hideDados").show();
    $("#bnt_voltar").addClass("hide");
    $(".corpoErro").addClass("hide");
    $(".btnhide").show();
}
