using Dapper;
using Sow.Automation.Data.Contexto;
using Sow.Automation.Data.Entidades.ComandoContexto;
using Sow.Automation.Data.Entidades.ServicosRoboContexto;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.Cqrs.Queries;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.Interfaces;
using Sow.Automation.Data.Repositorios.Queries;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Sow.Automation.Data.Repositorios
{
    public class CustasRepository : ICustasRepository
    {
        DashBoardDbContext _context;

        public CustasRepository(DashBoardDbContext context)
        {
            _context = context;
        }
        public CommandResponse AdicionarCusta(EstadosVsCustas custa)
        {
            try
            {
                using (_context.Connection)
                {
                    _context.GetConnection();

                    var param = new DynamicParameters();
                    param.Add(name: "IdEstado", value: custa.IdEstado, direction: System.Data.ParameterDirection.Input);
                    param.Add(name: "De", value: custa.De, direction: System.Data.ParameterDirection.Input);
                    param.Add(name: "Ate", value: custa.Ate, direction: System.Data.ParameterDirection.Input);

                    _context.Connection.Execute(CustasQueries.InsertCustas(), param);

                    return new CommandResponse(true, $"Custa adicionada com sucesso");
                }

            }
            catch (SQLiteException ex)
            {
                return new CommandResponse(false, $"Erro : {ex.Message}");
            }
        }

        public CommandResponse EditarCusta(EstadosVsCustas custa)
        {
            try
            {
                using (_context.Connection)
                {
                    _context.GetConnection();
                    _context.Connection.Execute(CustasQueries.UpdateCustas(custa));

                    return new CommandResponse(true, $"Custa Atualizada com sucesso");
                }

            }
            catch (SQLiteException ex)
            {
                return new CommandResponse(true, $"Erro : {ex.Message}");
            }
        }

        public IEnumerable<CustasQueryResult> ObterTodosDetalhado()
        {
            try
            {
                using (_context.Connection)
                {
                    _context.GetConnection();
                    return _context
                            .Connection
                            .Query<CustasQueryResult>(CustasQueries.SelectCustasDetalhado(), new { });
                }

            }
            catch (SQLiteException ex)
            {
                throw ex;
            }
        }

        public CommandResponse RemoverCusta(long IdEstado)
        {
            try
            {
                using (_context.Connection)
                {
                    _context.GetConnection();
                    _context.Connection.Execute(CustasQueries.DeleteCustas(IdEstado));

                    return new CommandResponse(true, $"Custa Removida com sucesso");
                }

            }
            catch (SQLiteException ex)
            {
                return new CommandResponse(false, $"Erro : {ex.Message}");
            }
        }
    }
}
