using Dapper;
using Sow.Automation.Data.Contexto;
using Sow.Automation.Data.Entidades.UsuarioAplicacaoContexto;
using Sow.Automation.Data.Entidades.UsuarioAplicacaoContexto.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Automation.Data.Repositorios
{
    public class UserRepository : IUserRepository
    {
        DashBoardDbContext _context;

        public UserRepository(DashBoardDbContext context)
        {
            _context = context;
        }
        public void AdicionarUsuario(UsuarioAplicacao usr)
        {
            throw new NotImplementedException();
        }
        public UsuarioAplicacao ObterUsuario(UsuarioAplicacao usr)
        {

            string query = string.Format("Select * from Usuario where NomeUsuario = '{0}' and SenhaUsuario = '{1}'", usr.NomeUsuario, usr.SenhaUsuario);
            try
            {
                using (_context.Connection)
                {
                    _context.GetConnection();

                    return _context
                            .Connection
                            .Query<UsuarioAplicacao>(query, new { }).FirstOrDefault();
                };
            }
            catch (SQLiteException ex)
            {

                throw ex;
            }
        }

        public UsuarioAplicacao ObterUsuarioPorId(long Id)
        {
            string query = string.Format("Select * from Usuario where Id = '{0}'", Id);
            try
            {
                using (_context.Connection)
                {
                    _context.GetConnection();

                    return _context
                            .Connection
                            .Query<UsuarioAplicacao>(query, new { }).FirstOrDefault();
                };
            }
            catch (SQLiteException ex)
            {

                throw ex;
            }
        }
    }
}
