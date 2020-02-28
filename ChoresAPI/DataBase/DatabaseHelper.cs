using ChoresAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ChoresAPI.DataBase
{
    public class DatabaseHelper
    {
        public static ObservableCollection<User> GetUsers(string connectionString)
        {
            ObservableCollection<User> headers = new ObservableCollection<User>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("common.GetUsers"))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var user = new User
                            {
                                FullName = reader[1].ToString(),
                                ID = reader[0].ToString(),
                                Birthday = reader[2].ToString()
                            };
                            headers.Add(user);
                        }
                    }

                    reader.Close();
                    connection.Close();
                }
            }

            return headers;
        }
    }
}
