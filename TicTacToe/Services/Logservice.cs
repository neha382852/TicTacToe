using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.DatabaseLayer;
using TicTacToe.Model;

namespace TicTacToe
{
    public class Logservice
    {
        public void Add(Logger logObject)
        {
            SQLConnectionEstablisher obj = new SQLConnectionEstablisher();
            SqlConnection connection = obj.createConnection();
            SqlCommand cmd;
            string query;
            connection.Open();
            query = "insert into LogDetails values(@Request,@Response,@Exception)";
            cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add(new SqlParameter("@Request", logObject.Request));
            cmd.Parameters.Add(new SqlParameter("@Response", logObject.Response));
            cmd.Parameters.Add(new SqlParameter("@Exception", logObject.Exception));
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
