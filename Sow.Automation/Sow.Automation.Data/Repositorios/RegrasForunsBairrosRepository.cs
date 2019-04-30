using Dapper;
using Sow.Automation.Data.Contexto;
using Sow.Automation.Data.Entidades.ComandoContexto;
using Sow.Automation.Data.Entidades.ServicosRoboContexto;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.Cqrs.Queries;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.Cqrs.Queries.FiltrosParametros;
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
    public class RegrasForunsBairrosRepository : Repository, IRegrasForunsBairrosRepository
    {

        DashBoardDbContext _context;

        public RegrasForunsBairrosRepository(DashBoardDbContext context) : base(context)
        {
            _context = context;
        }

        public CommandResponse AdicionarRegraBairro(RegrasForunsBairros regra)
        {
            try
            {
                using (_context.Connection)
                {
                    _context.GetConnection();

                    var param = new DynamicParameters();
                    param.Add(name: "IdEstado", value: regra.IdEstado, direction: System.Data.ParameterDirection.Input);
                    param.Add(name: "IdCidade", value: regra.IdCidade, direction: System.Data.ParameterDirection.Input);
                    param.Add(name: "IdComarca", value: regra.IdComarca, direction: System.Data.ParameterDirection.Input);
                    param.Add(name: "IdBairro", value: regra.IdBairro, direction: System.Data.ParameterDirection.Input);
                    param.Add(name: "Regra", value: regra.Regra, direction: System.Data.ParameterDirection.Input);
                    param.Add(name: "Status", value: regra.Status, direction: System.Data.ParameterDirection.Input);

                    var t = _context.Connection.Execute(RegrasForunsQueries.InsertRegraBairro(), param);

                    return new CommandResponse(true, $"{regra.Regra} adicionada com sucesso");
                }
            }
            catch (SQLiteException ex)
            {
                return new CommandResponse(false, $"Erro : {ex.Message}");
            }
        }

        public CommandResponse AtualizarRegraBairro(RegrasForunsBairros regra)
        {
            try
            {
                using (_context.Connection)
                {
                    _context.GetConnection();
                    _context.Connection.Execute(RegrasForunsQueries.UpdateRegraBairro(regra));
                    return new CommandResponse(true, $"{regra.Regra} atualizada com sucesso");
                }
            }
            catch (SQLiteException ex)
            {
                return new CommandResponse(false, $"Erro : {ex.Message}");
            }
        }

        public RegrasForunsBairros ObtemRegraBairro(FiltroBairroCommand filtro)
        {
            try
            {
                using (_context.Connection)
                {
                    _context.GetConnection();
                    return _context
                             .Connection
                             .Query<RegrasForunsBairros>(RegrasForunsQueries.SelectRegraBairro(filtro), new { }).FirstOrDefault();
                }
            }
            catch (SQLiteException ex)
            {

                throw ex;
            }
        }

        public RegraBairroQueryResult ObtemRegraBairroDetalhado(FiltroBairroCommand filtro)
        {
            var query = RegrasForunsQueries.SelectBairroDetalhado(filtro);

            try
            {
                using (_context.Connection)
                {
                    _context.GetConnection();
                    return _context
                             .Connection
                             .Query<RegraBairroQueryResult>(query, new { }).FirstOrDefault();
                }
            }
            catch (SQLiteException ex)
            {
                throw ex;
            }
        }

        public IEnumerable<RegraBairroQueryResult> ObterTodosBairrosDetalhado()
        {
            var query = RegrasForunsQueries.SelectTodosBairrosDetalhados();

            try
            {
                using (_context.Connection)
                {
                    _context.GetConnection();
                    return _context
                             .Connection
                             .Query<RegraBairroQueryResult>(query, new { });
                }
            }
            catch (SQLiteException ex)
            {
                throw ex;
            }
        }

        public CommandResponse RemoverRegraBairro(RegrasForunsBairros regra)
        {
            try
            {
                using (_context.Connection)
                {
                    var t = RegrasForunsQueries.DeleteRegraBairro(regra);
                    _context.GetConnection();
                    _context.Connection.Execute(RegrasForunsQueries.DeleteRegraBairro(regra));
                    return new CommandResponse(true, $" Regra removida com sucesso");
                }
            }
            catch (SQLiteException ex)
            {
                return new CommandResponse(true, $"Erro : {ex.Message}");
            }
        }
    }
}
