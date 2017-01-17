using System.Runtime.Serialization;

namespace Assets.DO
{
    [DataContract]
    public class District
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ProvinceId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public byte Order { get; set; }
        [DataMember]
        public System.DateTime CreateDate { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
    }
}
