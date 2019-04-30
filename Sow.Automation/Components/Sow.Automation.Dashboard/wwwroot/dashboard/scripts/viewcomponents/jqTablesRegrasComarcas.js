$(document).ready(function () {


    $('#idtableRegras thead th').each(function () {
        var title = $(this).text();
        if (title == "Remover" || title == "Salvar" || title == "Editar") {
            $(this).html('<span> ' + title + '</span>');
        }
        else {
            $(this).html('<input style="color:grey;" type="text" placeholder="' + title + '" />');
        }  
    });

    var table = $('#idtableRegras').DataTable({
        "aLengthMenu": [[10, 20, 30, 40, 50, -1], [10, 20, 30, 40, 50, "All"]],
       "pageLength": 10,
       "ordering": false,
        "stateSaveParams": function (settings, data) {
            data.search.search = "";
        },

        stateSaveCallback: function (settings, data) {
            localStorage.setItem('idtableRegras', JSON.stringify(data));
        },
        stateLoadCallback: function () {
            try {
                return JSON.parse(localStorage.getItem('idtableRegras'));
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
            "infoEmpty": "Mostrando 0 regras",
            "infoFiltered": "(Filtrado de um total de _MAX_ regras)",
            "search": "_INPUT_",
            "searchPlaceholder": "Procurar por ..."
        },

    });

   // Apply the search
   table.columns().every(function () {
       var that = this;

       $('input', this.header()).on('keyup change', function () {
           if (that.search() !== this.value) {
               that
                   .search(this.value)
                   .draw();
           }
       });
   });


});

