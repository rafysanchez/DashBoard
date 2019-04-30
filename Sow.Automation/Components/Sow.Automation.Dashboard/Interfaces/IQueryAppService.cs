
using Sow.Automation.Dashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sow.Automation.Dashboard.Interfaces
{
  public  interface IQueryAppService
    {
        IList<CidadeViewModel>   ObterCidades();
        IList<ComarcasViewModel> ObterComarcas();
        IList<BairrosViewModel>  ObterBairros();
        IList<EstadosViewModel>  ObterEstados();
        IList<RegrasForunsBrasilViewModel> ObterRegras();
        IList<RegrasForunsBairrosViewModel> ObterRegrasBairro();
        IList<RegrasForunsBairrosViewModel> ObterTabelaBairros();
        IList<RegrasForunsBairrosViewModel> ObterTabelaCidades();
        IList<RegrasForunsBairrosViewModel> ObterTabelaComarcas();
        IList<EstadosVsCustasViewModel> ObterTabelaCustas();
    }
}
