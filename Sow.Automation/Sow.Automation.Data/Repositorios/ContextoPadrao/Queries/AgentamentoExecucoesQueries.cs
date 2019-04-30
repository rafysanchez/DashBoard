using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Automation.Data.Repositorios.ContextoPadrao.Queries
{
  public static  class AgentamentoExecucoesQueries
    {
        public static string InsertExecucao()
        {
            return "INSERT INTO AgendamentoExecucoes (IdExecucao, IdProcesso, MensagemStatus, Inicio, Fim, Status) VALUES ( @IdExecucao, @IdProcesso, @MensagemStatus, @Inicio, @Fim,@Status)";
        }
        public static string ObterExecucaoPorId(string id)
        {
            return $"Select * AgendamentoExecucoes where IdProcesso = '{id}'";
        }
        public static string ObterTodasExecucoes()
        {
            return "Select * from AgendamentoExecucoes";
        }

    }
}
