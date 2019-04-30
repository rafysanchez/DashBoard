using Dapper;
using Sow.Automation.Data.Contexto;
using Sow.Automation.Data.Entidades.ComandoContexto;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.ContextoPadrao;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.Interfaces.ContextoPadrao;
using Sow.Automation.Data.Repositorios.ContextoPadrao.Queries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Automation.Data.Repositorios.ContextoPadrao
{
    public class AgendamentoRepository : IAgendamentoRepository
    {

        DashBoardDbContext _contexto;

        public AgendamentoRepository(DashBoardDbContext context)
        {
            _contexto = context;
        }

        public CommandResponse AdicionarAgendamento(AgendamentoInfo obj)
        {
            try
            {
                _contexto.Connection.Open();
                _contexto.BeginTransaction();
                var query = AgendamentoInfoQueries.InsertAgendamentoInfo();

                var param = new DynamicParameters();
                param.Add(name: "IdProcesso", value: obj.IdProcesso.ToString(), direction: ParameterDirection.Input);
                if (obj.DataInicio != DateTime.MinValue)
                    param.Add(name: "DataInicio", value: obj.DataInicio, direction: ParameterDirection.Input);
                else
                    param.Add(name: "DataInicio", value: null, direction: ParameterDirection.Input);


                param.Add(name: "Descricao", value: obj.Descricao, direction: ParameterDirection.Input);
                param.Add(name: "NomeAgente", value: obj.NomeAgente, direction: ParameterDirection.Input);
                param.Add(name: "Periodicidade", value: obj.Periodicidade.ToString(), direction: ParameterDirection.Input);
                param.Add(name: "FrequenciaPeriodicidade", value: obj.FrequenciaPeriodicidade, direction: ParameterDirection.Input);
                param.Add(name: "StatusAgendamento", value: obj.StatusAgendamento.ToString(), direction: ParameterDirection.Input);
                param.Add(name: "HoraInicio", value: obj.HoraInicio.ToString(), direction: ParameterDirection.Input);
                param.Add(name: "MinutoInicio", value: obj.MinutoInicio.ToString(), direction: ParameterDirection.Input);
                param.Add(name: "AmPm", value: obj.AmPm, direction: ParameterDirection.Input);
                param.Add(name: "Ativo", value: obj.Ativo, direction: ParameterDirection.Input);
                param.Add(name: "DisparoManual", value: obj.DisparoManual, direction: ParameterDirection.Input);
                param.Add(name: "Path_UltimaExecucao", value: obj.MinutoInicio.ToString(), direction: ParameterDirection.Input);

                _contexto.Connection.Execute(query, param, _contexto.Transaction);

                query = EmailInfoQueries.InsertEmailInfoPorId();
                param = new DynamicParameters();
                param.Add(name: "IdProcesso", value: obj.IdProcesso.ToString(), direction: ParameterDirection.Input);
                param.Add(name: "Assunto", value: obj.Email.Assunto, direction: ParameterDirection.Input);
                param.Add(name: "Remetente", value: obj.Email.Remetente, direction: ParameterDirection.Input);
                param.Add(name: "Destinatario", value: obj.Email.Destinatario, direction: ParameterDirection.Input);
                param.Add(name: "Destinatario_CC", value: obj.Email.Destinatario_CC, direction: ParameterDirection.Input);
                param.Add(name: "Destinatario_CO", value: obj.Email.Destinatario_CO, direction: ParameterDirection.Input);
                _contexto.Connection.Execute(query, param, _contexto.Transaction);

                _contexto.Transaction.Commit();
                _contexto.Dispose();

                return new CommandResponse(true, $"{obj.Descricao} adicionada com sucesso");


            }
            catch (SQLiteException ex)
            {
                _contexto.Transaction.Rollback();
                _contexto.Dispose();
                return new CommandResponse(false, $"{ex.Message}");
            }
        }

        public CommandResponse AtualizarAgendamentoInfoPorID(AgendamentoInfo obj)
        {
            try
            {
                _contexto.Connection.Open();
                _contexto.BeginTransaction();

                _contexto.Connection.Execute(AgendamentoInfoQueries.UpdateAgendamentoInfo(obj), _contexto.Transaction);
                _contexto.Connection.Execute(EmailInfoQueries.UpdateEmailInfoPorId(obj.Email), _contexto.Transaction);

                _contexto.Transaction.Commit();
                _contexto.Dispose();

                return new CommandResponse(true, $"{obj.Descricao} atualizado com sucesso");
            }
            catch (SQLiteException ex)
            {
                _contexto.Transaction.Rollback();
                _contexto.Dispose();
                return new CommandResponse(false, $"Erro : {ex.Message}");
            }
        }

        public CommandResponse AtualizarStatusAgendamento(AgendamentoInfo obj)
        {
            try
            {
                _contexto.Connection.Open();
                _contexto.Connection.Execute(AgendamentoInfoQueries.UpdateStatusExecucao(obj));
                _contexto.Dispose();

                return new CommandResponse(true, $"{obj.Descricao} atualizado com sucesso");
            }
            catch (SQLiteException ex)
            {
                _contexto.Dispose();
                return new CommandResponse(false, $"Erro : {ex.Message}");
            }
        }

        public AgendamentoInfo ObterAgendamento(string Id)
        {
            try
            {
                using (_contexto.Connection)
                {
                    _contexto.GetConnection();


                    var agendamento = _contexto
                     .Connection
                     .Query<AgendamentoInfo>(AgendamentoInfoQueries.SelectAgendamentoInfoPorId(Id.ToString()), new { Id = Id }).FirstOrDefault();

                    agendamento.AtualizaEmail(_contexto
                      .Connection
                        .Query<EmailInfo>(EmailInfoQueries.SelectEmailInfoPorId(Id.ToString()), new { Id = Id }).FirstOrDefault());

                    return agendamento;
                }
            }
            catch (SQLiteException ex)
            {

                throw ex;
            }
        }

        public IEnumerable<AgendamentoInfo> ObterTodosAgendamentos(int? quantidade = null)
        {
            try
            {
                using (_contexto.Connection)
                {
                    _contexto.GetConnection();
                    var q = AgendamentoInfoQueries.SelecionarTodos();
                 var agendamentos = _contexto
                  .Connection
                    .Query<AgendamentoInfo>(q, new { });


                    foreach (var ag in agendamentos)
                    {
                      ag.AtualizaEmail(_contexto
                        .Connection
                           .Query<EmailInfo>(EmailInfoQueries.SelectEmailInfoPorId(ag.IdProcesso.ToString()), new { Id = ag.IdProcesso.ToString() }).FirstOrDefault());
                    }

                    return agendamentos;
                }
            }
            catch (SQLiteException ex)
            {

                throw ex;
            }
        }

        public IEnumerable<AgendamentoInfo> ObterTodosAgendamentosEnfileirar()
        {
            try
            {
                using (_contexto.Connection)
                {
                    _contexto.GetConnection();
                    var q = AgendamentoInfoQueries.SelecionarAgendamentosEnfileirar();
                    var agendamentos = _contexto
                     .Connection
                       .Query<AgendamentoInfo>(q, new { });


                    foreach (var ag in agendamentos)
                    {
                        ag.AtualizaEmail(_contexto
                          .Connection
                             .Query<EmailInfo>(EmailInfoQueries.SelectEmailInfoPorId(ag.IdProcesso.ToString()), new { Id = ag.IdProcesso.ToString() }).FirstOrDefault());
                    }

                    return agendamentos;
                }
            }
            catch (SQLiteException ex)
            {

                throw ex;
            }
        }

        public CommandResponse RemoverAgendamentoInfoPorID(string IdProcesso)
        {
            try
            {
                _contexto.Connection.Open();
                _contexto.BeginTransaction();

                _contexto.Connection.Execute(AgendamentoInfoQueries.DeleteAgendamentoInfo(IdProcesso), _contexto.Transaction);
                _contexto.Connection.Execute(EmailInfoQueries.DeleteEmailInfo(IdProcesso), _contexto.Transaction);

                _contexto.Transaction.Commit();
                _contexto.Dispose();

                return new CommandResponse(true, $" Agendamento {IdProcesso} Removido com sucesso");
            }
            catch (SQLiteException ex)
            {
                _contexto.Transaction.Rollback();
                _contexto.Dispose();
                return new CommandResponse(false, $"Erro : {ex.Message}");
            }
        }
    }
}
