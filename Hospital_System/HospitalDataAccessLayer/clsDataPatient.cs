using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HospitalDataAccessLayer
{
    public class clsDataPatient
    {
        public static DataTable GetAllPatient()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM Patient";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception) { }
            finally { connection.Close(); }
            return dt;
        }
        public static int AddNewPatient(string Name, bool Gender, DateTime BirthDate, bool smoking, bool isFat)
        {
            int contactID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO Patient (Name, Gender, BirthDate, smoking, isFat)
                            VALUES (@Name, @Gender, @BirthDate, @smoking, @isFat);
                            SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@BirthDate", BirthDate);
            command.Parameters.AddWithValue("@smoking", smoking);
            command.Parameters.AddWithValue("@isFat", isFat);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    contactID = insertedID;
                }
            }catch (Exception) { }
            finally { connection.Close(); }
            return contactID;
        }
        public static bool GetPatientInfoByID(int ID, ref string Name, ref bool Gender, ref DateTime BirthDate, ref bool isSmoke, ref bool isFat)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM Patient WHERE ID = @ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Name = (string)reader["Name"];
                    Gender = (bool)reader["Gender"];
                    BirthDate = (DateTime)reader["BirthDate"];
                    isSmoke = (bool)reader["smoking"];
                    isFat = (bool)reader["isFat"];
                    isFound = true;
                }
                reader.Close();
            }
            catch (Exception) { isFound = false; }
            finally { connection.Close(); }
            return isFound;
        }

        public static bool UpdateContact(int ID, string Name, bool Gender, DateTime BirthDate, bool isSmoke, bool isFat)
        {
            int rowAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE Patient SET Name = @Name, Gender = @Gender, BirthDate = @BirthDate,
                             Smoking = @isSmoke, isFat = @isFat WHERE ID = @ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@BirthDate", BirthDate);
            command.Parameters.AddWithValue("@isSmoke", isSmoke);
            command.Parameters.AddWithValue("@isFat", isFat);

            try
            {
                connection.Open();
                rowAffected = command.ExecuteNonQuery();
            }
            catch (Exception) { return false; }
            finally{ connection.Close(); }
            return rowAffected > 0;
        }

        public static bool DeletePatientByID(int ID)
        {
            int rowAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "DELETE FROM Patient WHERE ID = @ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                rowAffected = command.ExecuteNonQuery();
            }
            catch { return false; }
            finally{ connection.Close(); }
            return rowAffected > 0;
        }
    }



}
