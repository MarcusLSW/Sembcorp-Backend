using MySql.Data.MySqlClient;
using SembcorpServices.Controllers;
using System;
using System.Collections.Generic;

namespace SembcorpServices.Models
{
    public class SosMessageDAO
    {
        private static string GET_ALL_SOS_MESSAGES = "select * from sos_message";
        private static string GET_SOS_MESSAGE_BY_GUID = "select * from sos_message where guid = @guid";
        private static string ADD_SOS_MESSAGE = "insert into sos_message vales(?, ?, ?, ?, ?)";
        private static string UPDATE_SOS_MESSAGE = "update sos_message set lat = ?, longi = ?, message = ? where uuid = ?";

        public List<SosMessage> GetAllSosMessage()
        {
            MySqlConnection conn = null;
            try
            {

                conn = ConnectionManager.GetConnection();
                MySqlCommand cmd = new MySqlCommand(GET_ALL_SOS_MESSAGES, conn);

                MySqlDataReader reader = cmd.ExecuteReader();
                List<SosMessage> sosMessages = new List<SosMessage>();

                while (reader.Read())
                {

                    Guid guid = reader.GetGuid(0);
                    string email = reader.GetString(1);
                    double lat = reader.GetDouble(2);
                    double longi = reader.GetDouble(3);
                    DateTime timeInitiated = reader.GetDateTime(4);

                    string message = reader.GetString(5);
                    bool isResolved = reader.GetBoolean(6);
                    DateTime lastUpdate = reader.GetDateTime(7);
                    
                    sosMessages.Add(new SosMessage(guid, email, lat, longi, timeInitiated, message, lastUpdate, isResolved));
                }

                return sosMessages;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
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

        public SosMessage GetbyGuid(Guid guid)
        {
            if (guid == null) return null;

            MySqlConnection conn = null;
            try
            {
                conn = ConnectionManager.GetConnection();
                MySqlCommand cmd = new MySqlCommand(GET_SOS_MESSAGE_BY_GUID, conn);
                cmd.Parameters.AddWithValue("@guid", guid);

                MySqlDataReader reader = cmd.ExecuteReader();

                guid = reader.GetGuid(0);
                string email = reader.GetString(1);
                double lat = reader.GetDouble(2);
                double longi = reader.GetDouble(3);
                DateTime timeInitiated = reader.GetDateTime(4);

                string message = reader.GetString(5);
                bool isResolved = reader.GetBoolean(6);
                DateTime lastUpdate = reader.GetDateTime(7);

                return new SosMessage(guid, email, lat, longi, timeInitiated, message, lastUpdate, isResolved);

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
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

        public bool AddSosMessage(SosMessage sosMessage)
        {
            if (sosMessage == null) { return false; }

            MySqlConnection conn = null;
            try
            {
                conn = ConnectionManager.GetConnection();
                MySqlCommand cmd = new MySqlCommand(ADD_SOS_MESSAGE, conn);

                
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return false;
        }
    }
}