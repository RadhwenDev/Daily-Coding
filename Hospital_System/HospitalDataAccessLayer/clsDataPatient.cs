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
            SqlCommand command = new SqlCommand(@query, connection);
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
    }


}
