using Dapper;
using Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Text;
using MySql.Data.MySqlClient;
using static Models.ParamsModel;

namespace Libs
{
    public class SystemTools
    {

        private readonly string _connectionString;

        public SystemTools(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MySQLServerConn");
        }
        public static IDbConnection Connection()
        {
            IDbConnection _db = new MySqlConnection(ParamsModel.DBCon.ToString());

            return _db;
        }


        public static string GetUserById()
        {
            using (var connection = Connection())
            {
                connection.Open();
                MySqlCommand command = (MySqlCommand) connection.CreateCommand();
                command.CommandText = "SET NAMES 'utf8mb4'";
                command.ExecuteNonQuery();

                var res = connection.Query<User>("GetUserById",
                        new { userId = 3 },
                        null, true, 0, commandType: CommandType.StoredProcedure).FirstOrDefault();

                return res?.Name ?? string.Empty;
            }
        }




        public async Task<string> GetUserByIdAsync(int userId)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new MySqlCommand("GetUserById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@userId", userId);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return reader.GetString("Name");
                        }
                    }
                }
            }

            return null;
        }
    }

}
