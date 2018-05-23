using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WpfApplication2
{
    class Data
    {

        private static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public static void Signup(User newUser)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("InsertUser", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    var UserNameParam = new SqlParameter("UserName", newUser.UserName);
                    var PassParam = new SqlParameter("Pass", newUser.Password);

                    command.Parameters.Add(UserNameParam);
                    command.Parameters.Add(PassParam);

                    conn.Open();
                    var rows = command.ExecuteNonQuery();
                }
            }
        }
    }
}
