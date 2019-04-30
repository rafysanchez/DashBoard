using Sow.Automation.Data.Entidades.ServicosRoboContexto;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.Cqrs.Queries.FiltrosParametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Automation.Data.Repositorios.Queries
{
    public static class RegrasForunsQueries
    {

        public static string SelectRegraDetalhado(string uf, string city, string comarca)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" \r \n Select D.Uf as Estado,A.IdEstado as IdEstado,A.IdCidade as IdCidade, A.IdComarca as IdComarca,C.Descricao as Comarca,B.Descricao as Cidade,A.Regra as Regra, A.Status as Status ");
            sb.Append(" \r \n From RegrasForunsBrasil A");
            sb.Append(" \r \n LEFT JOIN Cidades B ON (A.IdCidade == B.Id)");
            sb.Append(" \r \n INNER JOIN Comarcas C ON (A.IdComarca == C.Id)");
            sb.Append(" \r \n INNER JOIN Estados D ON (A.IdEstado == D.Id)");
            sb.AppendFormat(" \r \n WHERE C.Descricao = '{0}'", comarca.TrimEnd(' ').TrimStart(' '));

            if (!string.IsNullOrWhiteSpace(city))
                sb.AppendFormat(" \r \n AND B.Descricao = '{0}' ", city.TrimEnd(' ').TrimStart(' '));

            sb.AppendFormat(" \r \n AND D.Uf = '{0}'", uf.TrimEnd(' ').TrimStart(' '));
            return sb.ToString();
        }
        public static string SelectBairroDetalhado(FiltroBairroCommand filtro)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" \r \n Select A.Uf as Estado, B.Descricao as Comarca, C.Descricao as Cidade, A.Id as IdEstado,B.Id as IdComarca,C.Id as IdCidade,D.Id as IdBairro, D.Descricao as Bairro, E.Regra, E.Status");
            sb.Append(" \r \n From RegrasForunsBairros E");
            sb.Append(" \r \n LEFT JOIN Estados A ON (A.Id == E.IdEstado )");
            sb.Append(" \r \n LEFT JOIN Comarcas B ON (B.Id == E.IdComarca)");
            sb.Append(" \r \n LEFT JOIN Cidades C ON (C.Id == E.IdCidade)");
            sb.Append(" \r \n LEFT JOIN Bairros D ON (D.Id == E.IdBairro)");
            sb.AppendFormat(" \r \n Where A.Uf = '{0}'", filtro.Uf);
            sb.AppendFormat(" \r \n AND B.Descricao = '{0}'", filtro.Comarca);
            sb.AppendFormat(" \r \n AND C.Descricao = '{0}'", filtro.Cidade);
            sb.AppendFormat(" \r \n AND D.Descricao = '{0}'", filtro.Bairro);
            return sb.ToString();
        }
        public static string SelectTodosBairrosDetalhados()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" \r \n Select A.Uf as Estado, B.Descricao as Comarca, C.Descricao as Cidade, D.Descricao as Bairro,A.Id as IdEstado,B.Id as IdComarca,C.Id as IdCidade,D.Id as IdBairro, E.Regra, E.Status");
            sb.Append(" \r \n From RegrasForunsBairros E");
            sb.Append(" \r \n LEFT JOIN Estados A ON (A.Id == E.IdEstado )");
            sb.Append(" \r \n LEFT JOIN Comarcas B ON (B.Id == E.IdComarca)");
            sb.Append(" \r \n LEFT JOIN Cidades C ON (C.Id == E.IdCidade)");
            sb.Append(" \r \n LEFT JOIN Bairros D ON (D.Id == E.IdBairro)");
            return sb.ToString();
        }
        public static string SelectTodasRegrasDetalhado()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" \r \n Select D.Uf as Estado,A.IdEstado as IdEstado,A.IdCidade as IdCidade, A.IdComarca as IdComarca,C.Descricao as Comarca,B.Descricao as Cidade,A.Regra as Regra, A.Status as Status ");
            sb.Append(" \r \n From RegrasForunsBrasil A");
            sb.Append(" \r \n LEFT JOIN Cidades B ON (A.IdCidade == B.Id)");
            sb.Append(" \r \n LEFT JOIN Comarcas C ON (A.IdComarca == C.Id)");
            sb.Append(" \r \n LEFT JOIN Estados D ON (A.IdEstado == D.Id)");
            return sb.ToString();
        }
        public static string SelectRegra(string uf, string city, string comarca)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" \r \n Select A.* ");
            sb.Append(" \r \n From RegrasForunsBrasil A");
            sb.Append(" \r \n LEFT JOIN Cidades B ON (A.IdCidade == B.Id)");
            sb.Append(" \r \n LEFT JOIN Comarcas C ON (A.IdComarca == C.Id)");
            sb.Append(" \r \n LEFT JOIN Estados D ON (A.IdEstado == D.Id)");
            sb.AppendFormat(" \r \n WHERE C.Descricao = '{0}'", comarca.TrimEnd(' ').TrimStart(' '));

            if (!string.IsNullOrWhiteSpace(city))
                sb.AppendFormat(" \r \n AND B.Descricao = '{0}' ", city.TrimEnd(' ').TrimStart(' '));

            sb.AppendFormat(" \r \n AND D.Uf = '{0}'", uf.TrimEnd(' ').TrimStart(' '));
            return sb.ToString();
        }
        public static string SelectRegraBairro(FiltroBairroCommand filtro)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" \r \n Select E.*");
            sb.Append(" \r \n From RegrasForunsBairros E");
            sb.Append(" \r \n LEFT JOIN Estados A ON (A.Id == E.IdEstado )");
            sb.Append(" \r \n LEFT JOIN Comarcas B ON (B.Id == E.IdComarca)");
            sb.Append(" \r \n LEFT JOIN Cidades C ON (C.Id == E.IdCidade)");
            sb.Append(" \r \n LEFT JOIN Bairros D ON (D.Id == E.IdBairro)");
            sb.AppendFormat(" \r \n Where A.Uf = '{0}'", filtro.Uf);
            sb.AppendFormat(" \r \n AND B.Descricao = '{0}'", filtro.Comarca);
            sb.AppendFormat(" \r \n AND C.Descricao = '{0}'", filtro.Cidade);
            sb.AppendFormat(" \r \n AND D.Descricao = '{0}'", filtro.Bairro);
            return sb.ToString();
        }
        public static string SelectAll()
        {
            return "Select * from RegrasForunsBrasil";
        }
        public static string SelectGeneric(string table)
        {
            return $"Select * from {table}";
        }
        public static string SelectTodosLocaisDetalhado()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" \r \n SELECT D.Id as IdEstado,D.Nome as Estado,C.Id as IdComarca ,C.Descricao as Comarca,B.Id as IdCidade, B.Descricao as Cidade ,A.Id as IdBairro,A.Descricao as Bairro");
            sb.Append(" \r \n FROM Bairros A");
            sb.Append(" \r \n LEFT JOIN Cidades B ON (A.IdCidade == B.Id)");
            sb.Append(" \r \n LEFT JOIN Comarcas C ON (B.IdComarca == C.Id)");
            sb.Append(" \r \n LEFT JOIN Estados D ON (C.IdEstado == D.Id)");
            sb.Append(" \r \n Order by D.Nome,");
            sb.Append(" \r \n C.Descricao,");
            sb.Append(" \r \n B.Descricao,");
            sb.Append(" \r \n A.Descricao");
            return sb.ToString();
        }
        public static string SelectTodasCidadesDetalhado()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" \r \n SELECT D.Id as IdEstado,D.Nome as Estado,C.Id as IdComarca ,C.Descricao as Comarca,B.Id as IdCidade, B.Descricao as Cidade");
            sb.Append(" \r \n    From Cidades B ");
            sb.Append(" \r \n   LEFT JOIN Comarcas C ON (B.IdComarca == C.Id) ");
            sb.Append(" \r \n   LEFT JOIN Estados D ON (C.IdEstado == D.Id)");
            sb.Append(" \r \n   Order by D.Nome,");
            sb.Append(" \r \n   C.Descricao,");
            sb.Append(" \r \n   B.Descricao");
            return sb.ToString();
        }
        public static string SelectTodasComarcasDetalhado()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" \r \n SELECT D.Id as IdEstado,D.Nome as Estado,C.Id as IdComarca ,C.Descricao as Comarca");
            sb.Append("  \r \n From Comarcas C");
            sb.Append("  \r \n  LEFT JOIN Estados D ON (C.IdEstado == D.Id)");
            sb.Append("  \r \n  Order by D.Nome,");
            sb.Append("  \r \n  C.Descricao");
            return sb.ToString();
        }

        public static string InsertRegra()
        {
            return "INSERT INTO  RegrasForunsBrasil (IdEstado,IdComarca,IdCidade,Regra,Status) VALUES ( @IdEstado, @IdComarca, @IdCidade, @Regra, @Status)";
        }
        public static string InsertRegraBairro()
        {
            return "INSERT INTO  RegrasForunsBairros (IdEstado,IdComarca,IdCidade,IdBairro,Regra,Status) VALUES ( @IdEstado, @IdComarca, @IdCidade,@IdBairro, @Regra, @Status)";
        }

        public static string UpdateRegra(RegrasForunsBrasil regra)
        {
            if (regra.IdCidade == 0)
                return $"UPDATE RegrasForunsBrasil  SET Regra = '{regra.Regra}', Status = {regra.Status} WHERE IdEstado = {regra.IdEstado} AND IdComarca = {regra.IdComarca} AND IdCidade is null";
            else
                return $"UPDATE RegrasForunsBrasil  SET Regra = '{regra.Regra}', Status = {regra.Status} WHERE IdEstado = {regra.IdEstado} AND IdComarca = {regra.IdComarca} AND IdCidade = {regra.IdCidade}";

        }
        public static string UpdateApenasComarcaRegra(long idComarca, long idEstado, long idCidade)
        {
            return $"UPDATE RegrasForunsBrasil  SET IdComarca = '{idComarca}' WHERE IdEstado = {idEstado}  AND IdCidade = {idCidade}";
        }
        public static string UpdateApenasComarcaRegraBairro(long idComarca, long idEstado, long idCidade)
        {
            return $"UPDATE RegrasForunsBairros  SET IdComarca = '{idComarca}' WHERE IdEstado = {idEstado}  AND IdCidade = {idCidade}";
        }
        public static string UpdateRegraBairro(RegrasForunsBairros regra)
        {
            return $"UPDATE RegrasForunsBairros  SET Regra = '{regra.Regra.TrimEnd(' ').TrimStart(' ')}', Status = {regra.Status} WHERE IdEstado = {regra.IdEstado} AND IdComarca = {regra.IdComarca} AND IdCidade = {regra.IdCidade}";
        }


        public static string InsertCidade()
        {
            return "INSERT INTO  Cidades (IdEstado,IdComarca,Descricao) VALUES (@IdEstado,@IdComarca ,@Descricao)";
        }
        public static string InsertComarca()
        {
            return "INSERT INTO  Comarcas (IdEstado,Descricao) VALUES (@IdEstado,@Descricao)";
        }
        public static string InsertBairro()
        {
            return "INSERT INTO  Bairros (IdCidade,Descricao) VALUES (@IdCidade,@Descricao)";
        }


        public static string UpdateBairro(Bairro bairro)
        {
            return $"UPDATE Bairros SET Descricao = '{bairro.Descricao.TrimEnd(' ').TrimStart(' ')}', IdCidade = {bairro.IdCidade} WHERE Id = {bairro.Id}";
        }
        public static string UpdateCidade(Cidade cidade)
        {
            return $"UPDATE Cidades SET Descricao = '{cidade.Descricao.TrimEnd(' ').TrimStart(' ')}', IdEstado = {cidade.IdEstado}, IdComarca = {cidade.IdComarca} WHERE Id = {cidade.Id}";
        }
        public static string UpdateComarca(Comarca comarca)
        {
            return $"UPDATE Comarcas SET Descricao = '{comarca.Descricao.TrimEnd(' ').TrimStart(' ')}',IdEstado = {comarca.IdEstado} WHERE Id = {comarca.Id}";
        }

        public static string DeleteComarca(long id)
        {
            return $"DELETE from Comarcas  WHERE id = {id}";
        }
        public static string DeleteCidade(long id)
        {
            return $"DELETE from Cidades  WHERE id = {id}";
        }
        public static string DeleteBairro(long id)
        {
            return $"DELETE from Bairros  WHERE Id = {id}";
        }
        public static string DeleteRegra(RegrasForunsBrasil regra)
        {
            if (regra.IdCidade == 0)
                return $"DELETE from RegrasForunsBrasil  WHERE IdEstado = {regra.IdEstado} AND IdComarca = {regra.IdComarca} AND IdCidade is null";
            else
                return $"DELETE from RegrasForunsBrasil  WHERE IdEstado = {regra.IdEstado} AND IdComarca = {regra.IdComarca} AND IdCidade = {regra.IdCidade}";
        }
        public static string DeleteRegraBairro(RegrasForunsBairros regra)
        {
            return $"DELETE from RegrasForunsBairros  WHERE IdEstado = {regra.IdEstado} AND IdComarca = {regra.IdComarca} AND IdCidade = {regra.IdCidade} AND IdBairro = {regra.IdBairro}";
        }
    }
}
