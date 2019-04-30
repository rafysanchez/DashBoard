using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Automation.Data.Entidades.UsuarioAplicacaoContexto.Interfaces
{
    public interface IUserRepository
    {
        UsuarioAplicacao ObterUsuario(UsuarioAplicacao usr);
        UsuarioAplicacao ObterUsuarioPorId(long Id);
        void AdicionarUsuario(UsuarioAplicacao usr);
    }
}
