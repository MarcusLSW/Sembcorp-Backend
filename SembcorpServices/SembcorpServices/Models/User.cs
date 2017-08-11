using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace SembcorpServices.Models
{
    [Serializable]
    [DataContract(Name = "User")]
    public class User
    {
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int ContactNumber { get; set; }
        [DataMember]
        public int RegionCode { get; set; }
        [DataMember]
        public bool IsAdmin { get; set; }
        [DataMember]
        public bool IsMale { get; set; }
        [DataMember]
        public double Lat { get; set; }
        [DataMember]
        public double Longi { get; set; }

        [JsonConstructor]
        public User(string email, string name, string isAdmin, string isMale)
        {
            Email = email;
            Name = name;
            IsAdmin = bool.TrueString.Equals(isAdmin);
            IsMale = bool.TrueString.Equals(isMale);
        }

        public User (string email, string name, bool isAdmin, bool isMale)
        {
            Email = email;
            Name = name;
            IsAdmin = isAdmin;
            IsMale = isMale;
        }

        public User(string email, string name, int contactNumber, int regionCode, bool isAdmin, bool isMale, double lat, double longi)
        {
            Email = email;
            Name = name;
            ContactNumber = contactNumber;
            RegionCode = regionCode;
            IsAdmin = isAdmin;
            IsMale = isMale;
            Lat = lat;
            Longi = longi;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            var temp = obj as User;

            return this.Email.Equals(temp.Email);
        }

        public override int GetHashCode()
        {
            return Email.GetHashCode();
        }

        public override string ToString()
        {
            return "User: " + Name + " Email: " + Email;
        }

    }
}