$('#btnLogin').click(function () {
    event.preventDefault();
    ValidaLoginSenha()
})

function ValidaLoginSenha() {

    var tabela = $("form[name='validatelogin']").serialize();

    $.ajax({
        type: "POST",
        url: '/Home/ValidarLoginSenha',
        dataType: 'html',
        data: tabela,
        success: function (message) {
       
            if (message == "0") {
                window.location.href = '/Home/Index';
            }
            if (message == "1") {
                $('#idErro').fadeIn();
                $('#idErro').html("Usuario ou Senha Invalidos!");

                window.setTimeout(function () {
                    $('#idErro').fadeOut();
                }, 2000);


            }

            if (message == "2") {
                $('#idErro').html("Usuario Ja cadastrado no sistema");
                window.setTimeout(function () {
                    $('#idErro').fadeOut();
                }, 2000);
            }

        },

        error: function (erro) {
            console.log(erro);
        }
    });
}