using System;
using System.Collections.Generic;
using System.Text;

namespace Sow.Automation.Dashboard.ViewModels
{
  public  class GerenciaRegrasViewModel
    {
        public GerenciaRegrasViewModel()
        {
            Estados = new List<EstadosViewModel>();
            Comarcas = new List<ComarcasViewModel>();
            Cidades = new List<CidadeViewModel>();
            Bairros = new List<BairrosViewModel>();
            Regras = new List<RegrasForunsBrasilViewModel>();
            RegrasBairros = new List<RegrasForunsBairrosViewModel>();
            Custas = new List<EstadosVsCustasViewModel>();
            Dados = new List<long>();
        }
        public string Fluxo { get; set; }
        public List<EstadosViewModel> Estados { get; set; }
        public List<ComarcasViewModel> Comarcas { get; set; }
        public List<CidadeViewModel> Cidades { get; set; }
        public List<BairrosViewModel> Bairros { get; set; }
        public List<RegrasForunsBrasilViewModel> Regras { get; set; }
        public List<RegrasForunsBairrosViewModel> RegrasBairros { get; set; }
        public List<EstadosVsCustasViewModel> Custas { get; set; }
        public List<long> Dados { get; set; }


        public void PopulaLista(List<EstadosViewModel> estados)
        {
            Estados = estados;
        }
        public void PopulaLista(List<ComarcasViewModel> comarcas)
        {
            Comarcas = comarcas;
        }
        public void PopulaLista(List<CidadeViewModel> cidades)
        {
            Cidades = cidades;
        }
        public void PopulaLista(List<BairrosViewModel> bairros)
        {
            Bairros = bairros;
        }
        public void PopulaLista(List<RegrasForunsBrasilViewModel> regras)
        {
            Regras = regras;
        }
        public void PopulaLista(List<RegrasForunsBairrosViewModel> regrasBairros)
        {
            RegrasBairros = regrasBairros;
        }
        public void PopulaLista(List<EstadosVsCustasViewModel> custas)
        {
            Custas = custas;
        }

        public void PopulaLista(List<long> dados)
        {
            Dados = dados;
        }
    }
}
