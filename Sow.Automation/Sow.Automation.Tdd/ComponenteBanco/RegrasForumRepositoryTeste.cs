using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sow.Automation.Data.Contexto;
using Sow.Automation.Data.Entidades.ServicosRoboContexto;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.Interfaces;
using Sow.Automation.Data.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Automation.Tdd.ComponenteBanco
{
    [TestClass]
    public class RegrasForumRepositoryTeste
    {
        IRegrasForumRepository _repo;
        IRegrasForunsBairrosRepository _repob;
        public RegrasForumRepositoryTeste()
        {
            _repo = new RegrasForumRepository(new Data.Contexto.DashBoardDbContext());
            _repob = new RegrasForunsBairrosRepository(new DashBoardDbContext());
        }

        //[TestMethod]
        //public void ADeveInserirTodosItens()
        //{
        //    Assert.AreEqual(true, _repo.AdicionarCidade(1,1, "Teste Adicionar Cidade").Ok);
        //    Assert.AreNotEqual(null, _repo.ObterTodos<Cidade>("Cidades").ToList().Find(a => a.Descricao == "Teste Adicionar Cidade"));

        //    Assert.AreEqual(true, _repo.AdicionarComarca(1, "Teste Adicionar Comarca").Ok);
        //    Assert.AreNotEqual(null, _repo.ObterTodos<Comarca>("Comarcas").ToList().Find(a => a.Descricao == "Teste Adicionar Comarca"));

        //    var cidade = _repo.ObterTodos<Cidade>("Cidades").ToList().Find(a => a.Descricao == "Teste Adicionar Cidade");
        //    var comarca = _repo.ObterTodos<Comarca>("Comarcas").ToList().Find(a => a.Descricao == "Teste Adicionar Comarca");


        //    Assert.AreEqual(true, _repo.AdicionarRegra(new RegrasForunsBrasil(1, comarca.Id, cidade.Id, "Teste Adicionar Regra", true)).Ok);
        //    Assert.AreNotEqual(null, _repo.ObterTodos<RegrasForunsBrasil>("RegrasForunsBrasil").ToList().Find(a => a.Regra == "Teste Adicionar Regra"));
        //}

        [TestMethod]
        public void BDeveSelecionarTodosItens()
        {
            var cidades = _repo.ObterTodos<Cidade>("Cidades");
            Assert.IsTrue(cidades.Count() >= 0);
            Assert.AreNotEqual(null, cidades);

            var estados = _repo.ObterTodos<Estado>("Estados");
            Assert.AreNotEqual(null, estados);
            Assert.IsTrue(estados.Count() >= 0);

            var regrasForuns = _repo.ObterTodos<RegrasForunsBrasil>("RegrasForunsBrasil");
            Assert.AreNotEqual(null, regrasForuns);
            Assert.IsTrue(regrasForuns.Count() >= 0);

            var regrasForunsBairros = _repo.ObterTodos<RegrasForunsBairros>("RegrasForunsBairros");
            Assert.AreNotEqual(null, regrasForunsBairros);
            Assert.IsTrue(regrasForunsBairros.Count() >= 0);

            var comarcas = _repo.ObterTodos<Comarca>("Comarcas");
            Assert.AreNotEqual(null, comarcas);
            Assert.IsTrue(comarcas.Count() >= 0);

            var regra = _repo.ObterPorCidadeEComarca("SC", "", "São José");
            Assert.AreNotEqual(null, regra);


            var regras = _repo.ObterTodasRegrasDetalhado();
            Assert.AreNotEqual(null, regras);
            Assert.IsTrue(regras.Count() >= 0);

        }

        //[TestMethod]
        //public void CDeveAtualizarTodosItens()
        //{

        //    var cidade = _repo.ObterTodos<Cidade>("Cidades").ToList().Find(a => a.Descricao == "Teste Adicionar Cidade");
        //    var comarca = _repo.ObterTodos<Comarca>("Comarcas").ToList().Find(a => a.Descricao == "Teste Adicionar Comarca");
        //    var regra = _repo.ObterPorCidadeEComarca("AC", "Teste Adicionar Cidade", "Teste Adicionar Comarca");


        //    Assert.AreEqual(true, _repo.AtualizarCidade(new Cidade(cidade.Id,cidade.IdEstado, cidade.IdEstado, "Update Ascurra")).Ok);
        //    Assert.AreEqual(true, _repo.AtualizarComarca(new Comarca(comarca.Id, comarca.IdEstado, "Update Meleiro")).Ok);
        //    Assert.AreEqual(true, _repo.AtualizarRegra(new RegrasForunsBrasil(regra.IdEstado, regra.IdComarca, regra.IdEstado, "Vara Regional de Direito Bancário de Rio do Sul - Update", false)).Ok);
        //}

        //[TestMethod]
        //public void DDeveRemoverTodosItens()
        //{

        //    var cidade = _repo.ObterTodos<Cidade>("Cidades").ToList().Find(a => a.Descricao == "Update Ascurra");
        //    var comarca = _repo.ObterTodos<Comarca>("Comarcas").ToList().Find(a => a.Descricao == "Update Meleiro");

        //    Assert.AreEqual(true, _repo.RemoverRegra(new RegrasForunsBrasil(1, comarca.Id, cidade.Id, "Teste Adicionar Regra", true)).Ok);
        //    Assert.AreEqual(true, _repo.RemoverCidade(cidade.Id).Ok);
        //    Assert.AreEqual(true, _repo.RemoverComarca(comarca.Id).Ok);

        //}

        //[TestMethod]
        //public void EInserirTodasRegras()
        //{





        //    var bairros = _repo.ObterTodos<Bairro>("Bairros").ToList().FindAll(a => a.IdCidade == 63).ToList();
        //    var index = bairros.FindIndex(a => a.Descricao == "Jardim Ibirapuera");
        //    var nextindex = bairros.FindIndex(a => a.Descricao == "Chacara Bom Jesus Pirapora");

        //    var lista = bairros.Skip(index).ToList();
        //    var nlista = lista.Take(nextindex - index + 1).ToList();


        //    foreach (var bairro in nlista)
        //    {
        //        var idBairro = bairro.Id;
        //        var idCidade = 63;
        //        var idEstado = 24;
        //        var idComarca = 51;
        //        _repob.AdicionarRegraBairro(new RegrasForunsBairros(idEstado, idComarca, idCidade, idBairro, "Mimosa", true));



        //    }
        //}

        private List<string> OrganizaPrimeiraLetraMaiuscula(List<string> bairros)
        {
            List<string> bairrosformat = new List<string>();

            foreach (var bairro in bairros)
            {
                var brtmp = bairro.Split(' ');

                string vword = "";
                string vFinal = "";

                foreach (var word in brtmp)
                {
                    if (!(word.TrimStart(' ').TrimEnd(' ').Length <= 2))
                    {
                        vword = word.ToLower().TrimStart(' ').TrimEnd(' ');
                        var c1 = $"{vword[0].ToString().ToUpper()}{vword.Substring(1, vword.Length - 1)}";
                        vword = c1;
                        vFinal += $"{c1} ";
                    }
                    else
                    {
                        vFinal += $"{word.ToLower().TrimStart(' ').TrimEnd(' ')} ";
                    }
                }
                bairrosformat.Add(vFinal);
            }
            return bairrosformat;
        }
    }
}
