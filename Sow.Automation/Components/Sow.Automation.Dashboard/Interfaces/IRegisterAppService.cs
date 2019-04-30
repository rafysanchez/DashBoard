
using Sow.Automation.Dashboard.ViewModels;
using Sow.Automation.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sow.Automation.Dashboard.Interfaces
{
  public  interface IRegisterAppService
    {
        void RegistrarComarca(ComarcasViewModel comarca);
        void RegistrarCidade(CidadeViewModel cidade);      
        void RegistrarBairro(BairrosViewModel bairro);      
        void RegistrarRegra(RegrasForunsBrasilViewModel regra);
        void RegistrarRegraBairro(RegrasForunsBairrosViewModel regraBairro);
        void RegistrarCusta(EstadosVsCustasViewModel custa);


        void AtualizarComarca(ComarcasViewModel comarca);
        void AtualizarCidade(CidadeViewModel bairro);
        void AtualizarBairro(BairrosViewModel bairro);
        void AtualizarRegra(RegrasForunsBrasilViewModel regra);
        void AtualizarRegraBairro(RegrasForunsBairrosViewModel regraBairro);
        void AtualizarCusta(EstadosVsCustasViewModel custa);

        void RemoverRegra(RegrasForunsBrasilViewModel regra);
        void RemoverRegraBairro(RegrasForunsBairrosViewModel regraBairro);
        void RemoverComarca(ComarcasViewModel comarca);
        void RemoverCidade(CidadeViewModel cidade);
        void RemoverBairro(BairrosViewModel bairro);
        void RemoverCusta(EstadosVsCustasViewModel custa);




    }
}
