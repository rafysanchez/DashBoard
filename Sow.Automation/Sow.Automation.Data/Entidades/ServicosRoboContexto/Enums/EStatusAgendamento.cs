using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Automation.Data.Entidades.ServicosRoboContexto.Enums
{
    public enum EStatusAgendamento
    {
        Aguardando = 0,
        Executando = 1,
        Finalizado = 2,
        ManualExecutar = 3,
        NaFila = 4,
        FinalizadoComErro = 5
    }
}
