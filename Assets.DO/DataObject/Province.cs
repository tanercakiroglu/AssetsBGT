using System;
using System.Runtime.Serialization;

namespace Assets.DO.DataObject
{
    [DataContract]
    public class Province
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int CountryId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string PlateNo { get; set; }
        [DataMember]
        public string PhoneCode { get; set; }
        [DataMember]
        public byte Order { get; set; }
        [DataMember]
        public DateTime CreateDate { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
    }
}
