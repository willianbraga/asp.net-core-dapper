using System.Data;
using System;
using System.Data.SqlClient;
using WillStore.Shared;

namespace WillStore.Infra.StoreContext.DataContexts
{
    public class WillDataContext : IDisposable
    {

        public SqlConnection Connection { get; set; }

        public WillDataContext()
        {
            Connection = new SqlConnection(Settings.ConnectionString);
        }
        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
    }
}