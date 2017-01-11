using System;
using System.Runtime.Serialization;

namespace Assets.DO
{
    [DataContract]
    public class Country
    {
        [DataMember]
        public long ID;
        [DataMember]
        public string name;
        [DataMember]
        public string code;
        [DataMember]
        public string tripleCode;
        [DataMember]
        public int order;
        [DataMember]
        public DateTime createDate;
        [DataMember]
        public bool active;
        [DataMember]
        public string phoneCode;
    }
}
