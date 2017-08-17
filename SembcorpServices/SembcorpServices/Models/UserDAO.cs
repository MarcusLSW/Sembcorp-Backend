using MySql.Data.MySqlClient;
using SembcorpServices.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SembcorpServices.Models
{
    public class UserDAO
    {
        private static string GET_ALL_USERS = "select * from user";
        private static string GET_USERS_BY_EMAIL = "select * from user where email = @email";
        private static string ADD_USER = "INSERT INTO user (email, name, is_admin, is_male) values(@email, @name, @is_admin, @is_male)";
        private static string UPDATE_USER = "UPDATE USER SET email = @email, name = @name, contact_num = @contact_num, region_code = @region_code, is_admin = @is_admin, is_male = @is_male, lat = @lat, longi = @longi";
        private static string DELETE_USER = "DELETE FROM USER WHERE email = @email";
        public List<User> GetAllUsers()
        {
            MySqlConnection conn = null;
            try
            {
                conn = ConnectionManager.GetConnection();
                List<User> users = new List<User>();
                MySqlCommand cmd = new MySqlCommand(GET_ALL_USERS, conn);

                MySqlDataReader rs = cmd.ExecuteReader();

                while (rs.Read())
                {
                    string email = rs.GetString(0);
                    string name = rs.GetString(1);
                    int contactNumber = rs.GetInt32(2);
                    int regionCode = rs.GetInt32(3);
                    bool isAdmin = rs.GetBoolean(4);
                    bool isMale = rs.GetBoolean(5);
                    double lat = rs.GetDouble(6);
                    double longi = rs.GetDouble(7);

                    User user = new User(email, name, contactNumber, regionCode, isAdmin, isMale, lat, longi);
                    users.Add(user);
                }

                return users;
                
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }
            finally
            {
                if(conn != null && conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            
            return null;
        }

        public User GetUserByEmail(string email)
        {
            MySqlConnection conn = null;
            try
            {
                conn = ConnectionManager.GetConnection();
                List<User> users = new List<User>();
                MySqlCommand cmd = new MySqlCommand(GET_USERS_BY_EMAIL, conn);
                cmd.Parameters.AddWithValue("@email", email);

                MySqlDataReader rs = cmd.ExecuteReader();

                if (rs.Read())
                {
                    email = rs.GetString(0);
                    string name = rs.GetString(1);
                    int contactNumber = rs.GetInt32(2);
                    int regionCode = rs.GetInt32(3);
                    bool isAdmin = rs.GetBoolean(4);
                    bool isMale = rs.GetBoolean(5);
                    double lat = rs.GetDouble(6);
                    double longi = rs.GetDouble(7);

                    return new User(email, name, contactNumber, regionCode, isAdmin, isMale, lat, longi);
                }
                
            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.StackTrace.ToString());
            }
            finally
            {
                if (conn != null && conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                }
            }

            return null;
        }

        public bool AddUser(User user)
        {
            MySqlConnection conn = null;
            try
            {
                conn = ConnectionManager.GetConnection();

                MySqlCommand cmd = new MySqlCommand(ADD_USER, conn);

                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.Parameters.AddWithValue("@name", user.Name);
                cmd.Parameters.AddWithValue("@is_admin", user.IsAdmin);
                cmd.Parameters.AddWithValue("@is_male", user.IsMale);
                
                int count = cmd.ExecuteNonQuery();

                if (count == 1) return true;
                
            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.StackTrace.ToString());
            }
            finally
            {
                if (conn != null && conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                }
            }

            return false;
        }

        public bool UpdateUser (User user)
        {
            MySqlConnection conn = null;
            try
            {
                conn = ConnectionManager.GetConnection();

                MySqlCommand cmd = new MySqlCommand(ADD_USER, conn);

                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.Parameters.AddWithValue("@name", user.Name);
                cmd.Parameters.AddWithValue("@contact_num", user.ContactNumber);
                cmd.Parameters.AddWithValue("@region_code", user.RegionCode);
                cmd.Parameters.AddWithValue("@is_admin", user.IsAdmin);
                cmd.Parameters.AddWithValue("@is_male", user.IsMale);
                cmd.Parameters.AddWithValue("@lat", user.Lat);
                cmd.Parameters.AddWithValue("@longi", user.Longi);

                int count = cmd.ExecuteNonQuery();

                if (count == 1) return true;

            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.StackTrace.ToString());
            }
            finally
            {
                if (conn != null && conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                }
            }

            return false;
        }

        public bool DeleteUser (string id)
        {
            MySqlConnection conn = null;
            try
            {
                conn = ConnectionManager.GetConnection();

                MySqlCommand cmd = new MySqlCommand(DELETE_USER, conn);

                cmd.Parameters.AddWithValue("@email", id);

                int count = cmd.ExecuteNonQuery();

                if (count == 1) return true;


            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.StackTrace.ToString());
            }
            finally
            {
                if (conn != null && conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            return false;
        }
    }
}