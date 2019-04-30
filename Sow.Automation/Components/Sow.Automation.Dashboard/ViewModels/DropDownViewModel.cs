
using System;
using System.Collections.Generic;
using System.Text;

namespace Sow.Automation.Dashboard.ViewModels
{
    public class DropDownViewModel
    {
        public List<EstadosViewModel> Estados { get; set; }
        public List<ComarcasViewModel> Comarcas { get; set; }
        public List<CidadeViewModel> Cidades { get; set; }
        public List<BairrosViewModel> Bairros { get; set; }

        public DropDownViewModel()
        {
            Estados = new List<EstadosViewModel>();
            Comarcas = new List<ComarcasViewModel>();
            Cidades = new List<CidadeViewModel>();
            Bairros = new List<BairrosViewModel>();
        }

        public void PopulaLista(List<EstadosViewModel> lista)
        {
            Estados = lista;
        }
        public void PopulaLista(List<ComarcasViewModel> lista)
        {
            Comarcas = lista;
        }
        public void PopulaLista(List<CidadeViewModel> lista)
        {
            Cidades = lista;
        }
        public void PopulaLista(List<BairrosViewModel> lista)
        {
            Bairros = lista;
        }
    }
}
