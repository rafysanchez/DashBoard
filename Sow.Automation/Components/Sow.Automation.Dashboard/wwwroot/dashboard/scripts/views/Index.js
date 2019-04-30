timer = setInterval(function () {

    AtualizaCartoes();

}, 10000)

function SetTimersAgain() {
    timer = setInterval(function () {

        AtualizaCartoes();

    }, 10000)
}


function AtualizaResumo() {



    $('#idSpinRefresh').addClass('fa-spin');

    var url = '/Home/AtualizaResumoProcesso';

    $.ajax({
        type: "GET",
        url: url,
        contentType: 'application/json; charset=utf-8',
        dataType: 'html',
        success: function (message) {
            $('#ResumoProcessos').html(message);
            $('#idSpinRefresh').removeClass('fa-spin');
        },

        error: function () {

            alert('error');

        }
    });
}
function AtualizaCartoes() {

    var url = '/Home/AtualizaCartoes';

    $.ajax({
        type: "GET",
        url: url,
        contentType: 'application/json; charset=utf-8',
        dataType: 'html',
        success: function (message) {
            $('#IdCartoes').html(message);
        },

        error: function () {

            alert('error');

        }
    });
}



