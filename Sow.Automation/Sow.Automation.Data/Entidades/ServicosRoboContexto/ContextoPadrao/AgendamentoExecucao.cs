using Sow.Automation.Data.Entidades.ServicosRoboContexto.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Automation.Data.Entidades.ServicosRoboContexto.ContextoPadrao
{
    public class AgendamentoExecucao : EntidadeBase<AgendamentoExecucao>
    {
        public AgendamentoExecucao(
            string idProcesso,
            EStatusAgendamento status)
        {
            IdExecucao =  Guid.NewGuid().ToString();
            IdProcesso = idProcesso;
            Status = status;
        }

        private AgendamentoExecucao()
        {

        }
        #region Propriedades
        public string IdExecucao { get; private set; }
        public string IdProcesso { get; private set; }
        public string MensagemStatus { get; private set; }
        public DateTime Inicio { get; private set; }
        public DateTime Fim { get; private set; }
        public EStatusAgendamento Status { get; private set; }
        #endregion

        #region Metodos Publicos
        public override bool IsValid()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        private void Validar()
        {
            throw new NotImplementedException();
        }

        public void AtualizaDataInicio(DateTime data)
        {
            this.Inicio = data;
        }
        public void AtualizaDataFim(DateTime data)
        {
            this.Fim = data;
        }
        public void AtualizaStatus(EStatusAgendamento status)
        {
            this.Status = status;
        }
        public void AtualizaMensagemStatus(string status)
        {
            this.MensagemStatus = status;
        }
        #endregion
    }
}
