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
        public string InsertIntoDatabase(User userObject)
        {
            SQLConnectionEstablisher obj = new SQLConnectionEstablisher();
            SqlConnection connection = obj.createConnection();
            connection.Open();
            string Username = null;
            string response = null;
            string query = "Select * from UserDetails where Username=@Username";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add(new SqlParameter("@Username", userObject.Username));
            using (SqlDataReader datareader = cmd.ExecuteReader())
            {
                while (datareader.Read())
                {
                    Username = datareader["Username"].ToString();
                }
            }
            if (Username == null)
            {

                string token = Guid.NewGuid().ToString();
                userObject.AccessToken = token;
                query = "insert into UserDetails values(@Fname,@Lname,@Username,@AccessToken)";
                cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add(new SqlParameter("@Fname", userObject.Fname));
                cmd.Parameters.Add(new SqlParameter("@Lname", userObject.Lname));
                cmd.Parameters.Add(new SqlParameter("@Username", userObject.Username));
                cmd.Parameters.Add(new SqlParameter("@AccessToken", userObject.AccessToken));
                cmd.ExecuteNonQuery();
                response = "User has been Successfully added";
                connection.Close();
            }
          
            return response;
        }

        public string RetrieveFromDatabase(int id)
        {
            string token = null;
            SQLConnectionEstablisher obj = new SQLConnectionEstablisher();
            SqlConnection connection = obj.createConnection();
            connection.Open();
            string query = "select * from UserDetails where Id= @id";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add(new SqlParameter("@id", id));
            SqlDataReader datareader = cmd.ExecuteReader();
            while (datareader.Read())
            {
                token = datareader["AccessToken"].ToString();
            }

            return token;
        }


    }

}
