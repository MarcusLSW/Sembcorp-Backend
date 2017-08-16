using MySql.Data.MySqlClient;
using SembcorpServices.Controllers;
using System;
using System.Collections.Generic;

namespace SembcorpServices.Models
{
    public class EmergencyContactDAO
    {
        private static string GET_ALL_EMERGENCY_CONTACTS = "SELECT * FROM emergency_contact";
        private static string GET_GET_EMERGENCY_CONTACT_BY_LOCATION = "SELECT * FROM emergency_contact WHERE region_code = @region_code AND contact_number = @contact_number";
        private static string SET_EMERGENCY_CONTACT = "INSERT INTO emergency_contact VALUES(@name, @region_code, @num, @lat, @longi, @desc)";
        
        public List<EmergencyContact> GetAllEmergencyContacts()
        {
            MySqlConnection conn = null;
            try
            {
                conn = ConnectionManager.GetConnection();

                MySqlCommand cmd = new MySqlCommand(GET_ALL_EMERGENCY_CONTACTS , conn);

                MySqlDataReader rs = cmd.ExecuteReader();

                List<EmergencyContact> emergencyContacts = new List<EmergencyContact>();

                while (rs.Read())
                {
                    string name = rs.GetString(0);
                    int regionCode = rs.GetInt32(1);
                    int number = rs.GetInt32(2);
                    double lat = rs.GetDouble(3);
                    double longi = rs.GetDouble(4);
                    string desc = rs.GetString(5);

                    emergencyContacts.Add(new EmergencyContact(name, regionCode, number, lat, longi, desc));
                }

                return emergencyContacts;

            } catch (MySqlException ex)
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
        
        public EmergencyContact GetEmergencyContactById(string contactNumber)
        {
            string[] contact = contactNumber.Split('-');
            if (contact.Length < 2) return null;
            string regionCodeString = contact[0];
            string numberString = contact[1];

            MySqlConnection conn = null;

            try
            {
                int regionCode = Int32.Parse(regionCodeString);
                int number = Int32.Parse(numberString);

                conn = ConnectionManager.GetConnection();

                MySqlCommand cmd = new MySqlCommand(GET_GET_EMERGENCY_CONTACT_BY_LOCATION, conn);

                cmd.Parameters.AddWithValue("@region_code", regionCode);
                cmd.Parameters.AddWithValue("@contact_number", number);
                System.Diagnostics.Debug.WriteLine("regionCode: " + regionCode);
                System.Diagnostics.Debug.WriteLine("contactNumber: " + number);

                MySqlDataReader rs = cmd.ExecuteReader();

                if (rs.Read())
                {
                    string name = rs.GetString(0);
                    regionCode = rs.GetInt32(1);
                    number = rs.GetInt32(2);
                    double lat = rs.GetDouble(3);
                    double longi = rs.GetDouble(4);
                    string desc = rs.GetString(5);

                    return new EmergencyContact(name, regionCode, number, lat, longi, desc);
                }                
            }
            catch (MySqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
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
        
        public bool AddEmergencyContact(string locationName, int regionCode, int contactNumber, double lat, double longi, string desc)
        {
            MySqlConnection conn = null;
            try
            {
                conn = ConnectionManager.GetConnection();

                MySqlCommand cmd = new MySqlCommand(SET_EMERGENCY_CONTACT, conn);

                cmd.Parameters.AddWithValue("@name", locationName);
                cmd.Parameters.AddWithValue("@region_code", regionCode);
                cmd.Parameters.AddWithValue("@num", contactNumber);
                cmd.Parameters.AddWithValue("@lat", lat);
                cmd.Parameters.AddWithValue("@longi", longi);
                cmd.Parameters.AddWithValue("@desc", desc);

                int numOfRows = cmd.ExecuteNonQuery();

                if (numOfRows == 1) return true;

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

        public bool UpdateEmergencyContact(EmergencyContact ec)
        {
            MySqlConnection conn = null;
            try
            {

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