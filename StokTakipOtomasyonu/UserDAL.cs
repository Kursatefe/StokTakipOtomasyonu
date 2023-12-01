using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace StokTakipOtomasyonu
{
    internal class UserDAL
    {
        SqlConnection connection = new SqlConnection(@"server=(localdb)\MSSQLLocalDB; database=StokTakip; trusted_connection=true");
        void BaglantiyiAc()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        public DataTable UserlariDatatableileGetir()
        {
            DataTable table = new DataTable();
            BaglantiyiAc();
            SqlCommand sqlCommand = new SqlCommand("select*from Users", connection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            table.Load(reader);
            reader.Close();
            sqlCommand.Dispose();
            table.Dispose();
            connection.Close();
            return table;
        }
        public int Add(User user)
        {
            BaglantiyiAc();
            int islemSonucu = 0;
            SqlCommand sqlCommand = new SqlCommand("insert into Users (UserName,Password,FirstName,LastName,Email) values (@UserName,@Password,@FirstName,@LastName,@Email)", connection);
            sqlCommand.Parameters.AddWithValue("@UserName", user.UserName);
            sqlCommand.Parameters.AddWithValue("@Password", user.Password);
            sqlCommand.Parameters.AddWithValue("@FirstName", user.FirstName);
            sqlCommand.Parameters.AddWithValue("@LastName", user.LastName);
            sqlCommand.Parameters.AddWithValue("@Email", user.Email);
            islemSonucu = sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();
            connection.Close();

            return islemSonucu;
        }
        public User Get(int id)
        {
            User user = new User();
            BaglantiyiAc();
            SqlCommand sqlCommand = new SqlCommand("select*from Users where Id=@Id", connection);
            sqlCommand.Parameters.AddWithValue("@Id",id);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                user.Id = Convert.ToInt32(reader["Id"]);
                user.FirstName = Convert.ToString(reader["FirstName"]);
                user.LastName = Convert.ToString(reader["LastName"]);
                user.Password = Convert.ToString(reader["Password"]);
                user.Email = Convert.ToString(reader["Email"]);
                user.UserName = Convert.ToString(reader["UserName"]);
            }
            reader.Close();
            sqlCommand.Dispose();
            connection.Close();
            return user;

        }
        public int Update(User user)
        {
            BaglantiyiAc();
            int islemSonucu = 0;
            SqlCommand sqlCommand = new SqlCommand("Update Users set UserName=@UserName,Password=@Password,FirstName=@FirstName,LastName=@LastName,Email=@Email where Id=@Id", connection);
            sqlCommand.Parameters.AddWithValue("@Id", user.Id);
            sqlCommand.Parameters.AddWithValue("@UserName", user.UserName);
            sqlCommand.Parameters.AddWithValue("@Password", user.Password);
            sqlCommand.Parameters.AddWithValue("@FirstName", user.FirstName);
            sqlCommand.Parameters.AddWithValue("@LastName", user.LastName);
            sqlCommand.Parameters.AddWithValue("@Email", user.Email);
            islemSonucu = sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();
            connection.Close();

            return islemSonucu;
        }
        public int Delete (int id)
        {
            BaglantiyiAc();
            int islemSonucu = 0;
            SqlCommand sqlCommand = new SqlCommand("Delete from Users where Id=@Id", connection);
            sqlCommand.Parameters.AddWithValue("@Id",id);
            
            islemSonucu = sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();
            connection.Close();

            return islemSonucu;
        }
    }
}
