using Dapper;
using Sow.Automation.Data.Contexto;
using Sow.Automation.Data.Entidades.ComandoContexto;
using Sow.Automation.Data.Entidades.ServicosRoboContexto;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.Cqrs.Queries;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.Interfaces;
using Sow.Automation.Data.Repositorios.Queries;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Automation.Data.Repositorios
{
    public class RegrasForumRepository : Repository, IRegrasForumRepository
    {
        DashBoardDbContext _context;

        public RegrasForumRepository(DashBoardDbContext context) : base(context)
        {
            _context = context;
        }


        public CommandResponse AdicionarRegra(RegrasForunsBrasil regra)
        {
            try
            {
                using (_context.Connection)
                {
                    _context.GetConnection();

                    var param = new DynamicParameters();
                    param.Add(name: "IdEstado", value: regra.IdEstado, direction: System.Data.ParameterDirection.Input);
                    param.Add(name: "IdComarca", value: regra.IdComarca, direction: System.Data.ParameterDirection.Input);

                    if (regra.IdCidade == 0)
                        param.Add(name: "IdCidade", value: null, direction: System.Data.ParameterDirection.Input);
                    else
                        param.Add(name: "IdCidade", value: regra.IdCidade, direction: System.Data.ParameterDirection.Input);

                    param.Add(name: "Regra", value: regra.Regra, direction: System.Data.ParameterDirection.Input);
                    param.Add(name: "Status", value: regra.Status, direction: System.Data.ParameterDirection.Input);

                    var t = _context.Connection.Execute(RegrasForunsQueries.InsertRegra(), param);

                    return new CommandResponse(true, $"{regra.Regra} adicionada com sucesso");
                }

            }
            catch (SQLiteException ex)
            {
                return new CommandResponse(false, $"Erro : {ex.Message}");
            }
        }
        public CommandResponse AtualizarRegra(RegrasForunsBrasil regra)
        {
            try
            {
                using (_context.Connection)
                {
                    _context.GetConnection();
                    var query = RegrasForunsQueries.UpdateRegra(regra);

                    _context.Connection.Execute(query);
                    return new CommandResponse(true, $"{regra.Regra} atualizada com sucesso");
                }
            }
            catch (SQLiteException ex)
            {
                return new CommandResponse(false, $"Erro : {ex.Message}");
            }
        }
        public CommandResponse RemoverRegra(RegrasForunsBrasil regra)
        {
            try
            {
                using (_context.Connection)
                {
                    _context.GetConnection();
                    var query = RegrasForunsQueries.DeleteRegra(regra);

                    _context.Connection.Execute(query);

                    return new CommandResponse(true, $"{regra.Regra} removida com sucesso");
                }
            }
            catch (SQLiteException ex)
            {
                return new CommandResponse(false, $"Erro : {ex.Message}");
            }
        }
        public ICollection<RegrasForunsBrasil> ObterTodos()
        {
            try
            {
                using (_context.Connection)
                {
                    _context.GetConnection();

                    return _context
                           .Connection
                           .Query<RegrasForunsBrasil>(RegrasForunsQueries.SelectAll(), new { }).ToList();

                }
            }
            catch (SQLiteException ex)
            {
                throw ex;
            }
        }
        public RegrasForunsBrasil ObterPorCidadeEComarca(string uf, string city, string comarca)
        {
            var query = RegrasForunsQueries.SelectRegra(uf, city, comarca);

            try
            {
                using (_context.Connection)
                {
                    _context.GetConnection();
                    return _context
                             .Connection
                             .Query<RegrasForunsBrasil>(query, new { }).FirstOrDefault();
                }
            }
            catch (SQLiteException ex)
            {
                throw ex;
            }


        }

        public RegraBrasilQueryResult ObterPorCidadeEComarcaDetalhado(string uf, string city, string comarca)
        {
            var query = RegrasForunsQueries.SelectRegraDetalhado(uf, city, comarca);

            try
            {
                using (_context.Connection)
                {
                    _context.GetConnection();
                    return _context
                             .Connection
                             .Query<RegraBrasilQueryResult>(query, new { }).FirstOrDefault();
                }
            }
            catch (SQLiteException ex)
            {
                throw ex;
            }
        }


        public IEnumerable<RegraBrasilQueryResult> ObterTodasRegrasDetalhado()
        {
            var query = RegrasForunsQueries.SelectTodasRegrasDetalhado();

            try
            {
                using (_context.Connection)
                {
                    _context.GetConnection();
                    return _context
                             .Connection
                             .Query<RegraBrasilQueryResult>(query, new { });
                }
            }
            catch (SQLiteException ex)
            {
                throw ex;
            }
        }
    }
}
