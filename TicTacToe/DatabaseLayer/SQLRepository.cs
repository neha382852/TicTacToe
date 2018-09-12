using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.Model;

namespace TicTacToe.DatabaseLayer
{
    public class SQLRepository : IRepository
    {
        public void InsertIntoDatabase(User userObject)
        {
            SQLConnectionEstablisher obj = new SQLConnectionEstablisher();
            SqlConnection connection = obj.createConnection();
           /* query = "Select * from UserDetails where Email=@email";
            cmd = new SqlCommand(query, conobject);
            cmd.Parameters.Add(new SqlParameter("@email", userObject.Email));
            SqlDataReader datareader = cmd.ExecuteReader();
            while (datareader.Read())
            {
                email = datareader["Email"].ToString();
            }
            datareader.Close();
            */
            string token = Guid.NewGuid().ToString();
            userObject.AccessToken = token;
            string query = "insert into UserDetails values(@Fname,@Lname,@Username,@AccessToken)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add(new SqlParameter("@Fname", userObject.Fname));
            cmd.Parameters.Add(new SqlParameter("@Lname", userObject.Lname));
            cmd.Parameters.Add(new SqlParameter("@Username", userObject.Username));
            cmd.Parameters.Add(new SqlParameter("@AccessToken", userObject.AccessToken));
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
    
}
