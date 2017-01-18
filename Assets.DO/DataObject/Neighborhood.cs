using System;
using System.Runtime.Serialization;

namespace Assets.DO.DataObject
{
    [DataContract]
    public class Neighborhood
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int TownId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string ZipCode { get; set; }
        [DataMember]
        public byte Order { get; set; }
        [DataMember]
        public DateTime CreateDate { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
    }
}
