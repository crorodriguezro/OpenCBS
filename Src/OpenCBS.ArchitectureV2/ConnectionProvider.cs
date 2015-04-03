using System.Data;
using System.Data.SqlClient;
using OpenCBS.ArchitectureV2.Interface;
using OpenCBS.Shared.Settings;

namespace OpenCBS.ArchitectureV2
{
    public class ConnectionProvider : IConnectionProvider
    {
        public IDbConnection GetConnection()
        {
            var csb = new SqlConnectionStringBuilder();
            csb.DataSource = TechnicalSettings.DatabaseServerName;
            csb.InitialCatalog = TechnicalSettings.DatabaseName;
            csb.UserID = TechnicalSettings.DatabaseLoginName;
            csb.Password = TechnicalSettings.DatabasePassword;

            var connection = new SqlConnection(csb.ConnectionString);
            connection.Open();
            return connection;
        }
    }
}
