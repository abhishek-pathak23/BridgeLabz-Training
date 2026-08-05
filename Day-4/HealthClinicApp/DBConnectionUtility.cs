using System.Data;
using Microsoft.Data.SqlClient;

namespace HealthClinicApp
{
    public class DBConnectionUtility
    {
        private readonly string _connectionString;

        public DBConnectionUtility(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
