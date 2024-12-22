using System.Data;
using Dapper;
using System.Data.SqlClient;
namespace SendEMailDesign
{
    public static class DapperDatabase
    {
        static IDbConnection _connection;
        static bool _dataReaderState = true;
        static DapperDatabase()
            => _connection = new SqlConnection(Configuration.Db_Connection);
        public static IDbConnection Connection
        {
            get
            {
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();
                return _connection;
            }
        }
        public static async Task<IEnumerable<T>> QueryAsync<T>(string sql)
             => await _connection.QueryAsync<T>(sql);
        public static async Task<int> ExecuteAsync(string sql)
            => await _connection.ExecuteAsync(sql);
     
    
    }
}
