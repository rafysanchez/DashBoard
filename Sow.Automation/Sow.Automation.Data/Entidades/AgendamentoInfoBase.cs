using FluentValidation;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.ContextoPadrao;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sow.Automation.Data.Entidades
{
   public abstract class AgendamentoInfoBase : EntidadeBase<AgendamentoInfoBase>
    {
        #region Construtores

        protected AgendamentoInfoBase(string id,
         DateTime dataInicio,
         string descricao,
         string nM_Agente,
         ETipoPeriodicidade periodicidade,
         int frequenciaPeriodicidade,
         EStatusAgendamento statusAgendamento,
         int horaInicio,
         int minutoInicio,
         string aM_PM,
         bool ativo,
         bool disparoManual,
         EmailInfo email)
        {
            IdProcesso = id == Guid.Empty.ToString() ? Guid.NewGuid().ToString() : id;
            DataInicio = dataInicio.AddSeconds(-dataInicio.Second);
            Descricao = descricao ?? "";
            NomeAgente = nM_Agente ?? "";
            Periodicidade = periodicidade;
            FrequenciaPeriodicidade = frequenciaPeriodicidade;
            StatusAgendamento = statusAgendamento;
            HoraInicio = horaInicio;
            MinutoInicio = minutoInicio;
            AmPm = aM_PM ?? "";
            Ativo = ativo;
            DisparoManual = disparoManual;
            Email = email;
            FormataData();
        }
        protected AgendamentoInfoBase()
        {

        }



        #endregion


        #region Propriedades
        public string IdProcesso { get; protected set; }
        public DateTime DataInicio { get; protected set; }
        public DateTime DataProximaExecucao { get; protected set; }
        public DateTime DataUltimaExecucao { get; protected set; }
        public string Descricao { get; protected set; }
        public string NomeAgente { get; protected set; }
        public ETipoPeriodicidade Periodicidade { get; protected set; }
        public int? FrequenciaPeriodicidade { get; protected set; }
        public EStatusAgendamento StatusAgendamento { get; protected set; }
        public int? HoraInicio { get; protected set; }
        public int? MinutoInicio { get; protected set; }
        public string AmPm { get; protected set; }
        public bool Ativo { get; protected set; }
        public bool DisparoManual { get; protected set; }
        public EmailInfo Email { get; protected set; }
        #endregion


        #region Metodos Publicos
        protected void AtualizaEmail(EmailInfo email)
        {
            this.Email = email;
        }
        protected void FormataData()
        {
            if (this.AmPm.ToUpper() == "PM")
                DataInicio = this.DataInicio.AddHours(this.HoraInicio.Value + 12).AddMinutes(this.MinutoInicio.Value);
            else
                DataInicio = this.DataInicio.AddHours(this.HoraInicio.Value).AddMinutes(this.MinutoInicio.Value);
        }

        protected void AtualizarFrequenciaPeriodicidade(int data)
        {
            this.FrequenciaPeriodicidade = data;
        }
        protected void AtualizarDataUltimaExecucao(DateTime data)
        {
            this.DataUltimaExecucao = data.AddSeconds(-data.Second);
        }
        protected void AtualizaStatusExecucao(EStatusAgendamento status)
        {
            this.StatusAgendamento = status;
        }
        protected void AtualizarDataProxima(DateTime data)
        {
            this.DataProximaExecucao = data.AddSeconds(-data.Second);
        }
        public override bool IsValid()
        {
            Validar();
            return ValidationResult.IsValid;
        }


        protected string RetornaTipoExecucao()
        {
            if (DisparoManual)
                return $"Disparo {Periodicidade.ToString()}";
            else
                return $"{HoraInicio.Value.ToString("00")} : {MinutoInicio.Value.ToString("00")} {AmPm} - {Periodicidade.ToString()}";
        }

        #endregion

        #region Validations
        private void Validar()
        {
            ValidarNomeProcesso();
            ValidarNomeAgente();
            ValidarDataInicio();
            ValidaPeriodicidade();
            ValidaFrequenciaPeriodicidade();
            ValidaStatusAgendamento();
            ValidaMinutoInicio();
            ValidaHoraInicio();
            ValidarDataProximaExecucao();
            ValidarDataUltimaExecucao();
            ValidaAmPm();
            ValidaEmail();
            ValidationResult = Validate(this);
        }

        private void ValidaEmail()
        {
            RuleFor(c => c.Email)
                  .NotNull().WithMessage("O dado não pode ser vazio!");

            RuleFor(c => c.Email)
                  .Must(c => c.IsValid()).WithMessage("Dados Invalidos de e-mail");

        }

        private void ValidarNomeProcesso()
        {
            RuleFor(c => c.Descricao)
                  .NotEmpty().WithMessage("O Nome do Agendamento não pode ser vazio");
            RuleFor(c => c.Descricao)
                  .NotNull().WithMessage("O Nome do Agendamento não pode ser vazio");

            RuleFor(c => c.Descricao)
                 .Must(c => Regex.Match(c, @"^[a-zA-Z0-9'_ '-]*$").Success).WithMessage("Não é permitido utilizar caracteres especiais no nome do Agendamento");
        }

        private void ValidarNomeAgente()
        {
            RuleFor(c => c.NomeAgente)
                 .NotEmpty().WithMessage("O nome do Agente não pode ser vazio!");
            RuleFor(c => c.NomeAgente)
                 .NotNull().WithMessage("O nome do Agente não pode ser vazio!");

            RuleFor(c => c.NomeAgente)
                 .Must(c => Regex.Match(c, @"^[a-zA-Z0-9'_ '-]*$").Success).WithMessage("Não é permitido utilizar caracteres especiais no nome do Agente");
        }

        private void ValidarDataInicio()
        {
            if (!this.DisparoManual)
                RuleFor(c => c.DataInicio)
                .GreaterThanOrEqualTo(DateTime.Now).WithMessage("Verifique a data do agendamento");
        }

        private void ValidarDataProximaExecucao()
        {
            /// A FAZER: IMPLEMENTAR VALIDACAO
        }
        private void ValidarDataUltimaExecucao()
        {
            /// A FAZER: IMPLEMENTAR VALIDACAO
        }
        private void ValidaFrequenciaPeriodicidade()
        {
            RuleFor(c => c.FrequenciaPeriodicidade)
                .NotNull().WithMessage("O Valor de frequencia periodicidade não pode ser vazio!");
            RuleFor(c => c.FrequenciaPeriodicidade)
               .GreaterThanOrEqualTo(0).WithMessage("O Valor de frequencia periodicidade não pode ser menor que zero!");
        }
        private void ValidaPeriodicidade()
        {
            RuleFor(c => c.Periodicidade)
                .NotNull().WithMessage("O Valor de periodicidade não pode ser vazio!");
        }

        private void ValidaStatusAgendamento()
        {
            RuleFor(c => c.StatusAgendamento)
                .NotNull().WithMessage("O Valor de status agendamento não pode ser vazio!");
        }

        private void ValidaMinutoInicio()
        {
            if (!this.DisparoManual)
            {
                RuleFor(c => c.MinutoInicio)
                  .GreaterThanOrEqualTo(0).WithMessage("O minuto não pode ser menor que 0");
                RuleFor(c => c.MinutoInicio)
                      .NotNull().NotEmpty().WithMessage("O minuto não pode ser vazio ou nulo ");

                RuleFor(c => c.MinutoInicio)
                     .Must(c => Regex.Match(c.ToString(), "^[0-9]*$").Success).WithMessage("Não é permitido utilizar caracteres especiais no campo minuto");
            }

        }
        private void ValidaAmPm()
        {
            if (!this.DisparoManual)
            {
                if (!this.DisparoManual)
                    RuleFor(c => c.AmPm)
                      .NotNull().NotEmpty().WithMessage("O o valor de AmPm não pode ser nulo");

                RuleFor(c => c.AmPm)
                    .Must(AmPmValido)
                     .WithMessage("A hora inicio não pode ser maior que 12 caso seja escolhido PM");
            }

        }
        private void ValidaHoraInicio()
        {
            if (!this.DisparoManual)
            {
                RuleFor(c => c.HoraInicio)
                 .GreaterThanOrEqualTo(0).WithMessage("A hora não pode ser menor que 0");
                RuleFor(c => c.HoraInicio)
                      .NotNull().NotEmpty().WithMessage("A hora não pode ser vazio ou nulo ");

                RuleFor(c => c.HoraInicio)
                     .Must(c => Regex.Match(c.ToString(), "^[0-9]*$").Success).WithMessage("Não é permitido utilizar caracteres especiais no campo minuto");
            }

        }


        private bool AmPmValido(string valor)
        {
            if (valor.ToUpper() == "PM")
                return this.HoraInicio.Value <= 12;
            else
                return false;
        }

        #endregion
    }
}
