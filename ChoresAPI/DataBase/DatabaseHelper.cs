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

        public static string CreateUser(string connectionString, string fullName, string birthday)
        {
            var result = String.Empty;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("common.CreateUser"))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@FullName", fullName));
                    command.Parameters.Add(new SqlParameter("@Birthday", birthday));
                    command.Connection = connection;

                    connection.Open();
                    try
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        result = $"User Record for {fullName} has been saved";
                        reader.Close();
                    }
                    catch (Exception e)
                    {
                        result = $"User Record for {fullName} could not be saved because of {e}";
                    }
                    connection.Close();
                    return result;
                }
            }
        }
    }
}
