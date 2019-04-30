//Exibe o modal ao carregar a pagina inicial
$(document).ready(function () {
    $('#login-modal').modal('show');

});

// Fechar modal de login (Função temporária até que seja implementado um login verdadeiro com suas validações)
function FecharModal() {

    $(function () {
      $('#login-modal').modal('toggle');
    });
}