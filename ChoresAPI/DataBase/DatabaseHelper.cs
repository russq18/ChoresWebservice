using ChoresAPI.Models;
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace ChoresAPI.DataBase
{
    public class DatabaseHelper
    {
        #region User DB Calls
        public static ObservableCollection<User> GetUsers(string connectionString)
        {
            ObservableCollection<User> headers = new ObservableCollection<User>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using SqlCommand command = new SqlCommand("common.GetUsers");
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
            return headers;
        }
        public static string CreateUser(string connectionString, string fullName, string birthday)
        {
            string result;
            using SqlConnection connection = new SqlConnection(connectionString);
            using SqlCommand command = new SqlCommand("common.CreateUser");
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
        public static string UpdateUser(string connectionString, User user)
        {
            string result;
            using SqlConnection connection = new SqlConnection(connectionString);
            using SqlCommand command = new SqlCommand("common.UpdateUser");
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@ID", user.ID));
            command.Parameters.Add(new SqlParameter("@FullName", user.FullName));
            command.Parameters.Add(new SqlParameter("@Birthday", user.Birthday));


            command.Connection = connection;
            connection.Open();
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                result = $"User Record for {user.FullName} has been updated";
                reader.Close();
            }
            catch (Exception e)
            {
                result = $"User Record for {user.FullName} could not be updated because of {e}";
            }
            connection.Close();
            return result;
        }

        #endregion
        #region Chore Record DB Calls
        public static void GetChoreRecords(string connectionString, ChoreRecord record)
        {

        }
        public static void GetChoreRecord(string connectionString, ChoreRecord record)
        {

        }
        public static string CreateRecord(string connectionString, ChoreRecord record)
        {
            string result;
            using SqlConnection connection = new SqlConnection(connectionString);
            using SqlCommand command = new SqlCommand("common.CreateChoreRecord");
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@IsDone", Convert.ToInt32(record.IsDone)));
            command.Parameters.Add(new SqlParameter("@Date", record.DatePerformed));
            command.Parameters.Add(new SqlParameter("@TimeTaken", record.TimeTaken));
            command.Parameters.Add(new SqlParameter("@ChoreId", record.ChoreId));
            command.Parameters.Add(new SqlParameter("@FamilyId", record.FamilyId));
            command.Parameters.Add(new SqlParameter("@LocationId", record.LocationId));
            command.Parameters.Add(new SqlParameter("@UserId", record.UserId));


            command.Connection = connection;
            connection.Open();
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                result = $"Record for {record.ChoreName} performed on {record.DatePerformed} has been saved";
                reader.Close();
            }
            catch (Exception e)
            {
                result = $"Record for {record.ChoreName} performed on {record.DatePerformed} could not be saved because of {e}";
            }
            connection.Close();
            return result;
        }
        public static string UpdateChoreRecord(string connectionString, ChoreRecord record)
        {
            string result;
            using SqlConnection connection = new SqlConnection(connectionString);
            using SqlCommand command = new SqlCommand("common.UpdateChoreRecord")
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                Connection = connection
            };

            command.Parameters.Add(new SqlParameter("@ID", record.Id));
            command.Parameters.Add(new SqlParameter("@IsDone", Convert.ToInt32(record.IsDone)));
            command.Parameters.Add(new SqlParameter("@Date", record.DatePerformed));
            command.Parameters.Add(new SqlParameter("@TimeTaken", record.TimeTaken));
            command.Parameters.Add(new SqlParameter("@ChoreId", record.ChoreId));
            command.Parameters.Add(new SqlParameter("@FamilyId", record.FamilyId));
            command.Parameters.Add(new SqlParameter("@LocationId", record.LocationId));
            command.Parameters.Add(new SqlParameter("@UserId", record.UserId));

            connection.Open();
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                result = $"Record for {record.ChoreName} has been updated";
                reader.Close();
            }
            catch (Exception e)
            {
                result = $"Record for {record.ChoreName} could not be updated because of {e}";
            }
            connection.Close();
            return result;
        }
        #endregion
        #region Family DB Calls
        public static void GetFamily(string connectionString, Family family)
        {

        }
        public static string CreateFamily(string connectionString, Family family)
        {
            string result;
            using SqlConnection connection = new SqlConnection(connectionString);
            using SqlCommand command = new SqlCommand("common.CreateFamily");
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Name", family.Name));
            command.Parameters.Add(new SqlParameter("@Address", family.Address));

            command.Connection = connection;
            connection.Open();
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                result = $"Record for {family.Name} has been saved";
                reader.Close();
            }
            catch (Exception e)
            {
                result = $"Record for {family.Name} could not be saved because of {e}";
            }
            connection.Close();
            return result;
        }
        public static string UpdateFamily(string connectionString, Family family)
        {
            string result;
            using SqlConnection connection = new SqlConnection(connectionString);
            using SqlCommand command = new SqlCommand("common.UpdateFamily")
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            command.Parameters.Add(new SqlParameter("@ID", family.Id));
            command.Parameters.Add(new SqlParameter("@Name", family.Name));
            command.Parameters.Add(new SqlParameter("@Address", family.Address));

            command.Connection = connection;
            connection.Open();
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                result = $"Update Complete";
                reader.Close();
            }
            catch (Exception e)
            {
                result = $"Update for could not be completed because of {e}";
            }
            connection.Close();
            return result;
        }
        #endregion
        #region User Family DB Calls
        public static void GetUserFamily(string connectionString, UserFamily userfamily)
        {

        }
        public static string CreateUserFamily(string connectionString, UserFamily userfamily)
        {
            string result;
            using SqlConnection connection = new SqlConnection(connectionString);
            using SqlCommand command = new SqlCommand("common.CreateUserFamily");
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@FamilyRole", userfamily.Role));
            command.Parameters.Add(new SqlParameter("@UserId", userfamily.UserId));
            command.Parameters.Add(new SqlParameter("@FamilyId", userfamily.FamilyId));

            command.Connection = connection;
            connection.Open();
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                result = $"Record has been saved";
                reader.Close();
            }
            catch (Exception e)
            {
                result = $"Record for could not be saved because of {e}";
            }
            connection.Close();
            return result;
        }
        public static string UpdateUserFamily(string connectionString, UserFamily userFamily)
        {
            string result;
            using SqlConnection connection = new SqlConnection(connectionString);
            using SqlCommand command = new SqlCommand("common.UpdateUserFamily");
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@ID", userFamily.Id));
            command.Parameters.Add(new SqlParameter("@FamilyRole", userFamily.Role));
            command.Parameters.Add(new SqlParameter("@UserId", userFamily.UserId));
            command.Parameters.Add(new SqlParameter("@FamilyId", userFamily.FamilyId));

            command.Connection = connection;
            connection.Open();
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                result = $"Record has been updated";
                reader.Close();
            }
            catch (Exception e)
            {
                result = $"Record for could not be updated because of {e}";
            }
            connection.Close();
            return result;
        }
        #endregion
    }
}
