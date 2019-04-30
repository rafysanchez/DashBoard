using Sow.Automation.Data.Entidades.ServicosRoboContexto.ContextoPadrao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Automation.Data.Repositorios.ContextoPadrao.Queries
{
    public class AgendamentoInfoQueries
    {

        public static string InsertAgendamentoInfo()
        {
            return "INSERT INTO AgendamentoInfo (IdProcesso, DataInicio, Descricao, NomeAgente, Periodicidade,FrequenciaPeriodicidade, StatusAgendamento, HoraInicio, MinutoInicio, Ativo, AmPm, DisparoManual ) VALUES ( @IdProcesso, @DataInicio, @Descricao, @NomeAgente, @Periodicidade,@FrequenciaPeriodicidade, @StatusAgendamento, @HoraInicio, @MinutoInicio, @Ativo, @AmPm, @DisparoManual )";
        }

        public static string UpdateAgendamentoInfo(AgendamentoInfo ag)
        {
            return $"UPDATE AgendamentoInfo SET  DataInicio = '{ag.DataInicio}', DataProximaExecucao = '{ag.DataProximaExecucao}',DataUltimaExecucao = '{ag.DataUltimaExecucao}', Descricao = '{ag.Descricao}', NomeAgente = '{ag.NomeAgente}', Periodicidade = '{ag.Periodicidade}',FrequenciaPeriodicidade = {ag.FrequenciaPeriodicidade.Value}, StatusAgendamento = '{ag.StatusAgendamento}', HoraInicio = '{ag.HoraInicio}', MinutoInicio = '{ag.MinutoInicio}', Ativo = {ag.Ativo}, AmPm = '{ag.AmPm}', DisparoManual = {ag.DisparoManual}  Where IdProcesso = '{ag.IdProcesso}'";
        }
        public static string UpdateStatusExecucao(AgendamentoInfo ag)
        {
            return $"UPDATE AgendamentoInfo SET  DataProximaExecucao = '{ag.DataProximaExecucao}',DataUltimaExecucao = '{ag.DataUltimaExecucao}',  StatusAgendamento = '{ag.StatusAgendamento}'  Where IdProcesso = '{ag.IdProcesso}'";
        }

        public static string DeleteAgendamentoInfo(string id)
        {
            return $"DELETE FROM AgendamentoInfo  Where IdProcesso = '{id}'";
        }

        public static string SelectAgendamentoInfoPorId(string Id)
        {
            return $"SELECT  IdProcesso,DataInicio ,Descricao,NomeAgente,Periodicidade,FrequenciaPeriodicidade,StatusAgendamento ,HoraInicio,MinutoInicio,AmPm,Ativo,DisparoManual FROM AgendamentoInfo Where IdProcesso = '{Id}'";
        }

        public static string SelecionarTodos()
        {
            return $"SELECT  IdProcesso,DataInicio,DataProximaExecucao,DataUltimaExecucao ,Descricao,NomeAgente,Periodicidade,FrequenciaPeriodicidade,StatusAgendamento ,HoraInicio,MinutoInicio,AmPm,Ativo,DisparoManual FROM AgendamentoInfo";
        }
        public static string SelecionarAgendamentosEnfileirar()
        {
            return $"SELECT  IdProcesso,DataInicio,DataProximaExecucao,DataUltimaExecucao ,Descricao,NomeAgente,Periodicidade,FrequenciaPeriodicidade,StatusAgendamento ,HoraInicio,MinutoInicio,AmPm,Ativo,DisparoManual FROM AgendamentoInfo Where  Ativo = 1 AND DisparoManual = 0 AND StatusAgendamento not in ('NaFila','Executando')";
        }

        public static string SelectAgendamentoInfoPorId2(string Id)
        {
            return $"  SELECT  a.[IdProcesso] ,a.[DataInicio] ,a.[Descricao],a.[NomeAgente],a.[Periodicidade],a.[StatusAgendamento] ,a.[HoraInicio],a.[MinutoInicio],a.[AmPm],a.[Ativo],a.[DisparoManual],b.Remetente ,b.Assunto, b.Destinatario, b.Destinatario_CC, b.Destinatario_CO FROM [AutomacaoRelatorios].[dbo].[AgendamentoInfo] a, [AutomacaoRelatorios].[dbo].[EmailInfo] b Where a.[IdProcesso] = '{Id}'";
        }
    }
}
