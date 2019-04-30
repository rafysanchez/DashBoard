using Sow.Automation.Data.Entidades.ServicosRoboContexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Automation.Data.Repositorios.Queries
{
    public static class CustasQueries
    {
        public static string SelectCustasDetalhado()
        {
            return "SELECT B.Nome as Estado, A.* FROM EstadosVsCustas A INNER JOIN Estados B ON(A.IdEstado == B.Id)";
        }

        public static string InsertCustas()
        {
            return "INSERT INTO EstadosVsCustas (IdEstado,De,Ate) Values (@IdEstado,@De,@Ate)";
        }

        public static string UpdateCustas(EstadosVsCustas custa)
        {
            return $"UPDATE  EstadosVsCustas SET  De = {custa.De}, Ate = {custa.Ate} Where IdEstado = {custa.IdEstado}";
        }

        public static string DeleteCustas(long IdEstado)
        {
            return $"DELETE FROM  EstadosVsCustas  Where IdEstado = {IdEstado}";
        }
    }
}
