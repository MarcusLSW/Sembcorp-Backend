using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace SembcorpServices.Models
{
    [Serializable]
    [DataContract(Name = "EmergencyContact")]
    public class EmergencyContact
    {
        [DataMember]
        public string LocationName { get; set; }
        [DataMember]
        public string EmergencyNumber { get; set; }
        public int RegionCode { get; set; }
        public int ContactNumber { get; set; }
        [DataMember]
        public double Lat { get; set; }
        [DataMember]
        public double Longi { get; set; }
        [DataMember]
        public string Desc { get; set; }

        [JsonConstructor]
        public EmergencyContact(string locationName, int regionCode, int contactNumber, double lat, double longi, string desc)
        {
            LocationName = locationName;
            RegionCode = regionCode;
            ContactNumber = contactNumber;
            Lat = lat;
            Longi = longi;
            Desc = desc;
            EmergencyNumber = "+" + RegionCode + " " + contactNumber;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            EmergencyContact ec = obj as EmergencyContact;
            return (ec.RegionCode + " " + ec.ContactNumber) == (RegionCode + " " + ContactNumber);
        }

        public override int GetHashCode()
        {
            return (RegionCode + " " + ContactNumber).GetHashCode();
        }

        public override string ToString()
        {
            return RegionCode + " " + ContactNumber;
        }
    }
}