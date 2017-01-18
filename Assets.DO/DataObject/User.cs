using System.Runtime.Serialization;

namespace Assets.DO.DataObject
{
    [DataContract]
    public class User
    {
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
       
    }
}
