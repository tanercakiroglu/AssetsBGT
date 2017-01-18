using System;
using System.Runtime.Serialization;

namespace Assets.DO.DataObject
{
    [DataContract]
    public class Country 
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string TripleCode { get; set; }
        [DataMember]
        public int Order { get; set; }
        [DataMember]
        public DateTime CreateDate { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public string PhoneCode { get; set; }
    }
}
