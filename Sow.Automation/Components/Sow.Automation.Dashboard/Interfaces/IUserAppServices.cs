
using Sow.Automation.Dashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sow.Automation.Dashboard.Interfaces
{
   public interface IUserAppServices
    {
        bool Autenticar(UserLoginViewModel user);
        void AdicionarUsuario(UserLoginViewModel user);
        UserLoginViewModel ObterDadosUsuario(long id);
        void AtualizaDadosSessao(UserLoginViewModel dados, Microsoft.AspNetCore.Http.ISession sessao);
        bool ValidaSessaoUsuario(Microsoft.AspNetCore.Http.ISession sessao);
        string ChaveSessao();
        UserLoginViewModel ObtemDadosSessao(Microsoft.AspNetCore.Http.ISession sessao);
    }
}
