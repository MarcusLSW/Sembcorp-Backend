using MySql.Data.MySqlClient;
using SembcorpServices.Controllers;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace SembcorpServices.Models
{
    public class AdminAlertDAO
    {
        private static string GET_ALL_ADMIN_ALERTS = "select * from admin_alert";
        // One more query <GET_ADMIN_ALERT_BY_AREA> will also be added in a later time
        private static string GET_ADMIN_ALERT_BY_ID = "select * from admin_alert where id = @id";
        private static string INSERT_ADMIN_ALERT = "INSERT INTO `admin_alert` (`id`, `email`, `creation_date`, `lat`, `longi`, `alert`, `parent_id`, `child_id`) " +
            "VALUES (@id, @email, @creation_date, @lat, @longi, @alert, @parent_id, @child_id);";
        private static string UPDATE_ADMIN_ALERT_ALERT = "update admin_alert set alert = @alert where id = @id";
        private static string UPDATE_ADMIN_ALERT_ADD_CHILD = "update admin_alert set child_id = @child_id where id = @id";


        public List<AdminAlert> GetAllAlert()
        {
            MySqlConnection conn = null;
            try
            {
                conn = ConnectionManager.GetConnection();

                MySqlCommand cmd = new MySqlCommand(GET_ALL_ADMIN_ALERTS, conn);

                MySqlDataReader rs = cmd.ExecuteReader();

                List<AdminAlert> adminAlerts = new List<AdminAlert>();

                while (rs.Read())
                {
                    
                    Guid id = rs.GetGuid(0);
                    string email = rs.GetString(1);
                    DateTime creationDate = rs.GetDateTime(2);
                    double lat = rs.GetDouble(3);
                    double longi = rs.GetDouble(4);
                    string alert = rs.GetString(5);
                    Guid parentId = rs.GetGuid(6);
                    Guid childId = rs.GetGuid(7);
                    adminAlerts.Add(new AdminAlert(id, email, creationDate, lat, longi, alert, parentId, childId));
                    
                }

                return adminAlerts;

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.StackTrace.ToString());
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

        public AdminAlert GetAdminAlertById(Guid id)
        {
            MySqlConnection conn = null;
            try
            {
                conn = ConnectionManager.GetConnection();

                MySqlCommand cmd = new MySqlCommand(GET_ADMIN_ALERT_BY_ID, conn);
                cmd.Parameters.AddWithValue("@id", id);
                
                MySqlDataReader rs = cmd.ExecuteReader();

                rs.Read();
                
                id = rs.GetGuid(0);
                string email = rs.GetString(1);
                DateTime creationDate = rs.GetDateTime(2);
                double lat = rs.GetDouble(3);
                double longi = rs.GetDouble(4);
                string alert = rs.GetString(5);
                Guid parentId = rs.GetGuid(6);
                Guid childId = rs.GetGuid(7);
                
                return new AdminAlert(id, email, creationDate, lat, longi, alert, parentId, childId);
                
            }
            catch (MySqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message.ToString());
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

        public bool AddAdminAlert(AdminAlert adminAlert)
        {
            MySqlConnection conn = null;
            try
            {
                conn = ConnectionManager.GetConnection();

                MySqlCommand cmd = new MySqlCommand(INSERT_ADMIN_ALERT, conn);

                cmd.Parameters.AddWithValue("@id", adminAlert.Id.ToString());
                cmd.Parameters.AddWithValue("@email", adminAlert.Email);
                cmd.Parameters.AddWithValue("@creation_date", adminAlert.CreationDate.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                cmd.Parameters.AddWithValue("@lat", adminAlert.Lat);
                cmd.Parameters.AddWithValue("@longi", adminAlert.Longi);
                cmd.Parameters.AddWithValue("@alert", adminAlert.Alert);
                cmd.Parameters.AddWithValue("@parent_id", adminAlert.ParentId.ToString());
                cmd.Parameters.AddWithValue("@child_id", adminAlert.ChildId.ToString());

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 1) throw new Exception("repeated id");

                return true;
                
            }
            catch (MySqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message.ToString());
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

        // In case admin makes mistakes
        public bool UpdateMessage(Guid id, string alert)
        {
            MySqlConnection conn = null;
            try
            {
                conn = ConnectionManager.GetConnection();

                MySqlCommand cmd = new MySqlCommand(UPDATE_ADMIN_ALERT_ADD_CHILD, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@alert", alert);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 0) return false;
                if (rowsAffected > 0) throw new Exception("repeated id");

                return true;

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.StackTrace.ToString());
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

        public bool UpdateChild(Guid id, Guid childId)
        {
            MySqlConnection conn = null;
            try
            {
                conn = ConnectionManager.GetConnection();

                MySqlCommand cmd = new MySqlCommand(UPDATE_ADMIN_ALERT_ADD_CHILD, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@child_id", childId);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 0) return false;
                if (rowsAffected > 0) throw new Exception("repeated id");

                return true;

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.StackTrace.ToString());
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