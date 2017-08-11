using System;
using System.Runtime.Serialization;

namespace SembcorpServices.Models
{
    [Serializable]
    [DataContract(Name = "SosMessage")]
    public class SosMessage
    {
        [DataMember]
        public Guid SosId { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public double Lat { get; set; }
        [DataMember]
        public double Longi { get; set; }
        [DataMember]
        public DateTime TimeInitiated { get; set; }

        // Resources only available after subsequent updates
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public bool IsResolved { get; set; }
        [DataMember]
        public DateTime LastUpdate { get; set; }
        

        public SosMessage (Guid sosId, string email, double lat, double longi, DateTime timeInitiated, string message, DateTime lastUpdate, bool isResolved)
        {
            SosId = sosId;
            Email = email;
            Lat = lat;
            Longi = longi;
            TimeInitiated = timeInitiated;
            Message = message;
            LastUpdate = lastUpdate;
            IsResolved = isResolved;
        }

        public SosMessage (string email, double lat, double longi, DateTime timeInitiated)
        {
            SosId = Guid.NewGuid();
            Email = email;
            Lat = lat;
            Longi = longi;
            TimeInitiated = timeInitiated;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            var temp = obj as SosMessage;

            return this.SosId.Equals(temp.SosId);
        }

        public override int GetHashCode()
        {
            return SosId.GetHashCode();
        }

        public override string ToString()
        {
            return "User: " + Email + " Generated MessageId: " + SosId;
        }
    }
}