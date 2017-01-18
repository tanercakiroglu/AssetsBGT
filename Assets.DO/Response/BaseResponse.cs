using Assets.DO.Interface;
using System.Runtime.Serialization;
using System;

namespace Assets.DO.Response
{
    [DataContract]
    public class BaseResponse :IResponse
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

        public void PrepareException(Exception ex)
        {
            this.ErrorMessage = ex.Message;
            this.OperationStatus = false;
            this.Tag = "GeneralExcepiton";
        }
    }
}
