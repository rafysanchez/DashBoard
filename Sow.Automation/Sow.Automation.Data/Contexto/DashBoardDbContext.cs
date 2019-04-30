using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Automation.Data.Contexto
{
    public class DashBoardDbContext : IDisposable
    {
        public SQLiteConnection Connection { get; set; }
        public SQLiteTransaction Transaction { get; set; }

        public DashBoardDbContext()
        {
            GetConnection();
        }

        public void GetConnection() 
        {
            Connection = new SQLiteConnection(ConfigurationManager.AppSettings["SQLITEPRD"]);
        }

        public void BeginTransaction()
        {
            Transaction = this.Connection.BeginTransaction();
        }

        public void Commit()
        {
            Transaction.Commit();
        }

        public void Rollback()
        {
            Transaction.Rollback();
        }



        public void Dispose()
        {
            if (Connection.State != System.Data.ConnectionState.Closed)
                Connection.Close();
        }
    }
}
