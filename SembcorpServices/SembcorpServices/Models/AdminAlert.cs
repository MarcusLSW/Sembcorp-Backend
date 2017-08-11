using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SembcorpServices.Models
{
    [Serializable]
    [DataContract(Name = "AdminAlert")]
    public class AdminAlert
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public DateTime CreationDate { get; set; }
        [DataMember]
        public double Lat { get; set; }
        [DataMember]
        public double Longi { get; set; }
        [DataMember]
        public string Alert { get; set; }

        // This is to store relations for messages as admin will definately want to send
        // Updates on previous messages
        // We shall assume that every message only has one parent and child
        [DataMember]
        public Guid ParentId { get; }
        [DataMember]
        public Guid ChildId { get; set; }
        
        [JsonConstructor]
        public AdminAlert(string id, string email, string creationDate, double lat, double longi, string alert, string parentId, string childId)
        {
            Id = Guid.Parse(id);
            Email = email;
            CreationDate = DateTime.Parse(creationDate);
            Lat = lat;
            Longi = longi;
            Alert = alert;
            ParentId = Guid.Parse(parentId);
            ChildId = Guid.Parse(childId);
        }

        public AdminAlert(Guid id, string email, DateTime creationDate, double lat, double longi, string alert, Guid parentId, Guid childId)
        {
            Id = id;
            Email = email;
            CreationDate = creationDate;
            Lat = lat;
            Longi = longi;
            Alert = alert;
            ParentId = parentId;
            ChildId = childId;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            AdminAlert adminAlert = obj as AdminAlert;
            return adminAlert.Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return "Admin AlertId = " + Id;
        }
    }
}