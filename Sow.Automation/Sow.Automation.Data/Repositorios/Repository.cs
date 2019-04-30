using Dapper;
using Sow.Automation.Data.Contexto;
using Sow.Automation.Data.Entidades;
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
    public class Repository : IRepository
    {

        DashBoardDbContext _context;

        public Repository(DashBoardDbContext context)
        {
            _context = context;
        }
        public IEnumerable<T> ObterTodos<T>(string nomeTabela) where T : EntidadeBase<T>
        {
            try
            {
                var query = RegrasForunsQueries.SelectGeneric(nomeTabela);

                using (_context.Connection)
                {
                    _context.GetConnection();
                    return _context
                             .Connection
                             .Query<T>(query, new { });
                }
            }
            catch (SQLiteException ex)
            {
                throw ex;
            }
        }

        public CommandResponse AdicionarCidade(long idEstado, long idComarca, string cidade)
        {
            try
            {
                _context.GetConnection();

                var query = RegrasForunsQueries.InsertCidade();

                var param = new DynamicParameters();
                param.Add(name: "Descricao", value: cidade, direction: System.Data.ParameterDirection.Input);
                param.Add(name: "IdEstado", value: idEstado, direction: System.Data.ParameterDirection.Input);
                param.Add(name: "IdComarca", value: idComarca, direction: System.Data.ParameterDirection.Input);


                _context.Connection.Execute(query, param);

                return new CommandResponse(true, $"{cidade} adicionada com sucesso");
            }
            catch (SQLiteException ex)
            {

                return new CommandResponse(false, $"Erro : {ex.Message}");
            }
        }
        public CommandResponse AdicionarComarca(long idEstado, string comarca)
        {
            try
            {
                _context.GetConnection();
                var query = RegrasForunsQueries.InsertComarca();

                var param = new DynamicParameters();
                param.Add(name: "Descricao", value: comarca, direction: System.Data.ParameterDirection.Input);
                param.Add(name: "IdEstado", value: idEstado, direction: System.Data.ParameterDirection.Input);

                _context.Connection.Execute(query, param);
                return new CommandResponse(true, $"{comarca} adicionada com sucesso");
            }
            catch (SQLiteException ex)
            {
                return new CommandResponse(false, $"Erro : {ex.Message}");
            }
        }

        public CommandResponse AtualizarCidade(Cidade cidade)
        {
            try
            {
                _context.Connection.Open();
                _context.BeginTransaction();

                _context.Connection.Execute(RegrasForunsQueries.UpdateCidade(cidade), _context.Transaction);
                _context.Connection.Execute(RegrasForunsQueries.UpdateApenasComarcaRegra(cidade.IdComarca, cidade.IdEstado, cidade.Id), _context.Transaction);
                _context.Connection.Execute(RegrasForunsQueries.UpdateApenasComarcaRegraBairro(cidade.IdComarca, cidade.IdEstado, cidade.Id), _context.Transaction);

                _context.Transaction.Commit();
                _context.Dispose();
                return new CommandResponse(true, $"{cidade.Descricao} atualizada com sucesso");
            }
            catch (SQLiteException ex)
            {
                _context.Transaction.Rollback();
                _context.Dispose();
                return new CommandResponse(false, $"Erro : {ex.Message}");
            }
        }
        public CommandResponse AtualizarComarca(Comarca comarca)
        {
            try
            {
                using (_context.Connection)
                {
                    _context.GetConnection();
                    var query = RegrasForunsQueries.UpdateComarca(comarca);
                    _context.Connection.Execute(query);
                    return new CommandResponse(true, $"{comarca.Descricao} atualizada com sucesso");
                }
            }
            catch (SQLiteException ex)
            {
                return new CommandResponse(false, $"Erro : {ex.Message}");
            }
        }

        public CommandResponse RemoverCidade(long id)
        {
            try
            {
                using (_context.Connection)
                {
                    _context.GetConnection();
                    var query = RegrasForunsQueries.DeleteCidade(id);
                    _context.Connection.Execute(query);
                    return new CommandResponse(true, $"Cidade removida com sucesso");
                }
            }
            catch (SQLiteException ex)
            {
                return new CommandResponse(false, $"Erro : {ex.Message}");
            }
        }
        public CommandResponse RemoverComarca(long id)
        {
            try
            {
                using (_context.Connection)
                {
                    _context.GetConnection();
                    var query = RegrasForunsQueries.DeleteComarca(id);
                    _context.Connection.Execute(query);
                    return new CommandResponse(true, $"Comarca removida com sucesso");
                }
            }
            catch (SQLiteException ex)
            {
                return new CommandResponse(false, $"Erro : {ex.Message}");
            }
        }

        public CommandResponse AdicionarBairro(long idCidade, string bairro)
        {
            try
            {
                _context.GetConnection();

                var query = RegrasForunsQueries.InsertBairro();

                var param = new DynamicParameters();
                param.Add(name: "IdCidade", value: idCidade, direction: System.Data.ParameterDirection.Input);
                param.Add(name: "Descricao", value: bairro, direction: System.Data.ParameterDirection.Input);


                _context.Connection.Execute(query, param);

                return new CommandResponse(true,$"{bairro} adicionado com sucesso");
            }
            catch (SQLiteException ex)
            {
                return new CommandResponse(false, $"Erro : {ex.Message}");
            }
        }
        public CommandResponse RemoverBairro(long id)
        {
            try
            {
                using (_context.Connection)
                {
                    _context.GetConnection();
                    var query = RegrasForunsQueries.DeleteBairro(id);
                    _context.Connection.Execute(query);
                    return new CommandResponse(true, $"Bairro removido com sucesso");
                }
            }
            catch (SQLiteException ex)
            {
                return new CommandResponse(false, $"Erro : {ex.Message}");
            }
        }
        public CommandResponse AtualizarBairro(Bairro bairro)
        {
            try
            {
                using (_context.Connection)
                {
                    _context.GetConnection();
                    var query = RegrasForunsQueries.UpdateBairro(bairro);
                    _context.Connection.Execute(query);
                    return new CommandResponse(true, $"{bairro.Descricao} atualizada com sucesso");
                }
            }
            catch (SQLiteException ex)
            {
                return new CommandResponse(false, $"Erro : {ex.Message}");
            }
        }

        public IEnumerable<RegraBairroQueryResult> ObterTodosLocais()
        {
            try
            {
                var query = RegrasForunsQueries.SelectTodosLocaisDetalhado();

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

        public IEnumerable<RegraBairroQueryResult> ObterTodasCidades()
        {
            try
            {
                var query = RegrasForunsQueries.SelectTodasCidadesDetalhado();

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

        public IEnumerable<RegraBairroQueryResult> ObterTodasComarca()
        {
            try
            {
                var query = RegrasForunsQueries.SelectTodasComarcasDetalhado();

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
    }
}
