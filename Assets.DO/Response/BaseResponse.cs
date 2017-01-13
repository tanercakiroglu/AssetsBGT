using System.Runtime.Serialization;

namespace Assets.DO.Response
{
    [DataContract]
    public class BaseResponse
    {
        public BaseResponse()
        {
            OperationStatus = true;
            Tag = "SuccessfulOperation";
        }

        [DataMember]
        public bool OperationStatus { get; set; }

        [DataMember]
        public string Tag { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }
    }
}
