using Dapper;
using Sow.Automation.Data.Contexto;
using Sow.Automation.Data.Entidades.ComandoContexto;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.ContextoPadrao;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.Interfaces.ContextoPadrao;
using Sow.Automation.Data.Repositorios.ContextoPadrao.Queries;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Automation.Data.Repositorios.ContextoPadrao
{
    public class AgendamentoExecucoesRepository : IAgendamentoExecucoesRepository
    {

        DashBoardDbContext _contexto;

        public AgendamentoExecucoesRepository(DashBoardDbContext context)
        {
            _contexto = context;
        }

        public CommandResponse AdicionarExecucao(AgendamentoExecucao obj)
        {
            try
            {
                using (_contexto.Connection)
                {
                    _contexto.GetConnection();

                    var param = new DynamicParameters();
                    param.Add(name: "IdExecucao", value: obj.IdExecucao, direction: System.Data.ParameterDirection.Input);
                    param.Add(name: "IdProcesso", value: obj.IdProcesso, direction: System.Data.ParameterDirection.Input);
                    param.Add(name: "MensagemStatus", value: obj.MensagemStatus, direction: System.Data.ParameterDirection.Input);
                    param.Add(name: "Inicio", value: obj.Inicio, direction: System.Data.ParameterDirection.Input);
                    param.Add(name: "Fim", value: obj.Fim, direction: System.Data.ParameterDirection.Input);
                    param.Add(name: "Status", value: obj.Status, direction: System.Data.ParameterDirection.Input);

                    _contexto.Connection.Execute(AgentamentoExecucoesQueries.InsertExecucao(), param);

                    return new CommandResponse(true, $"Execucao adicionada com sucesso");
                }

            }
            catch (SQLiteException ex)
            {
                return new CommandResponse(false, $"Erro : {ex.Message}");
            }
        }

        public AgendamentoExecucao ObterExecucao(string Id)
        {
            try
            {
                using (_contexto.Connection)
                {
                    _contexto.GetConnection();


                    var execucao = _contexto
                     .Connection
                     .Query<AgendamentoExecucao>(AgentamentoExecucoesQueries.ObterExecucaoPorId(Id), new { Id = Id }).FirstOrDefault();

                    return execucao;
                }
            }
            catch (SQLiteException ex)
            {

                throw ex;
            }
        }

        public IEnumerable<AgendamentoExecucao> ObterTodasExecucoes(int? quantidade = null)
        {
            try
            {
                using (_contexto.Connection)
                {
                    _contexto.GetConnection();


                    var execucao = _contexto
                     .Connection
                     .Query<AgendamentoExecucao>(AgentamentoExecucoesQueries.ObterTodasExecucoes(), new {  });

                    return execucao;
                }
            }
            catch (SQLiteException ex)
            {

                throw ex;
            }
        }
    }
}
