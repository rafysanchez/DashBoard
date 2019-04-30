$(document).ready(function () {

    timerNotificacoes = setInterval(function () {

        AtualizaNotificacoes();

    }, 5000)

});




function AtualizaNotificacoes() {

    $.ajax({
        type: "GET",
        url: '/Home/Notificacoes',
        contentType: 'application/json; charset=utf-8',
        dataType: 'html',
        success: function (message) {
            $('#idNotificacoes').html(message);            
        },

        error: function () {

        }
    });

}
